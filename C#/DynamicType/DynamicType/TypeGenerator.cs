using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace DynamicType
{
    class TypeGenerator
    {
        public AssemblyBuilder GetAssemblyBuilder()
        {
            return AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()),
                AssemblyBuilderAccess.RunAndCollect);
        }

        public ModuleBuilder GetModule(AssemblyBuilder asmBuilder)
        {
            return asmBuilder.DefineDynamicModule(Guid.NewGuid().ToString());
        }

        public TypeBuilder GetTypeBuilder(ModuleBuilder modBuilder, string className)
        {
            return modBuilder.DefineType(className, TypeAttributes.Public);
        }

        //public TypeBuilder GetTypeBuilder(ModuleBuilder modBuilder, string className, params string[] genericparameters)
        //{
        //    TypeBuilder builder = modBuilder.DefineType(className, TypeAttributes.Public);
        //    GenericTypeParameterBuilder[] genBuilders = builder.DefineGenericParameters(genericparameters);

        //    // We take each generic type T : class, new()
        //    foreach (GenericTypeParameterBuilder genBuilder in genBuilders)
        //    {
        //        genBuilder.SetGenericParameterAttributes(
        //            GenericParameterAttributes.ReferenceTypeConstraint | GenericParameterAttributes.DefaultConstructorConstraint);
        //    }

        //    return builder;
        //}

        //public MethodBuilder GetMethod(TypeBuilder typBuilder, string methodName)
        //{
        //    MethodBuilder builder = typBuilder.DefineMethod(methodName,
        //                        MethodAttributes.Public | MethodAttributes.HideBySig);
        //    return builder;
        //}

        public MethodBuilder GetMethod(TypeBuilder typBuilder, string methodName,
            Type returnType, params Type[] parameterTypes)
        {
            MethodBuilder builder = typBuilder.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.HideBySig,
                CallingConventions.HasThis, returnType, parameterTypes);

            return builder;
        }

        //public MethodBuilder GetMethod(TypeBuilder typBuilder, string methodName, Type returnType,
        //    string[] genericParameters, params Type[] parameterTypes)
        //{
        //    MethodBuilder builder = typBuilder.DefineMethod(methodName, MethodAttributes.Public | MethodAttributes.HideBySig,
        //        CallingConventions.HasThis, returnType, parameterTypes);

        //    GenericTypeParameterBuilder[] genBuilders = builder.DefineGenericParameters(genericParameters);

        //    // We take each generic type T : class, new()
        //    foreach (GenericTypeParameterBuilder genBuilder in genBuilders)
        //    {
        //        genBuilder.SetGenericParameterAttributes(
        //            GenericParameterAttributes.ReferenceTypeConstraint | GenericParameterAttributes.DefaultConstructorConstraint);
        //    }

        //    return builder;
        //}

        public void CreateSumMethodInsideMyMath()
        {
            AssemblyBuilder asmbuilder = GetAssemblyBuilder();
            ModuleBuilder mbuilder = GetModule(asmbuilder);
            TypeBuilder tbuilder = GetTypeBuilder(mbuilder, "MyMath");

            Type[] tparams = { typeof(System.Int32), typeof(System.Int32) };
            MethodBuilder methodSum = this.GetMethod(tbuilder, "Sum", typeof(System.Single), tparams);

            ILGenerator generator = methodSum.GetILGenerator();

            generator.DeclareLocal(typeof(System.Single));
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Add_Ovf);
            generator.Emit(OpCodes.Conv_R4);
            generator.Emit(OpCodes.Stloc_0);

            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Ret);

            //Create the Type MyClass in the Assembly
            Type thistype = tbuilder.CreateType();

            MethodInfo info = thistype.GetMethod("Sum", BindingFlags.Instance | BindingFlags.Public);
            object thisObj = Activator.CreateInstance(thistype);

            object result = info.Invoke(thisObj, BindingFlags.Public | BindingFlags.CreateInstance, null, new object[] { 10, 20 }, 
                Thread.CurrentThread.CurrentCulture);

            Console.WriteLine("Sum of 10, 20 : {0}", result);
        }
    }
}
