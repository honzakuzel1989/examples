using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NullAttributes
{
    //
    // https://docs.microsoft.com/cs-cz/dotnet/csharp/language-reference/attributes/nullable-analysis
    //

    class Program
    {
        static void Main(string[] args)
        {
            // --
            var allowNull = new AllowNullCls();
            allowNull.Name = null;

            // --
            var disllowNull = new DisllowNullCls();
            disllowNull.State = "initialization";

            // --
            var maybeNull = new MaybeNullCls();
            var uq1 = maybeNull.FindUnique(1, 1, 2, 2);
            var uq2 = maybeNull.FindUnique("a", "b", "a", "b");

            // --
            var notNull = new NotNullCls();
            if (notNull.Contains("x", new[] { "a", "b", "a", "b" }).Value)
                ;

            // --
            var notNullWhen = new NotNullWhenCls();
            int? userid1 = 42;
            if (notNullWhen.HasRight(userid1))
                notNullWhen.DoSomething(userid1);

            // --
            var maybeNullWhen = new MaybeNullWhenCls();
            int? userid2 = null;
            if (!maybeNullWhen.HasRight(userid2))
                notNullWhen.DoSomething(userid2 ?? userid1);

            // --
            var notNullIfNotNull = new NotNullIfNotNullCls();
            var l = notNullIfNotNull.ToLower("test");
            notNullIfNotNull.Print(l);
            var u = notNullIfNotNull.ToUpper(null);
            notNullIfNotNull.Print(u ?? string.Empty);
        }
    }

    class AllowNullCls
    {
        //The general contract for that variable is that it shouldn't be null, so you want a non-nullable reference type.
        //There are scenarios for the input variable to be null, though they aren't the most common usage.

        private const string defaultname = "John";
        private string name = defaultname;

        [AllowNull]
        public string Name
        {
            get => name;
            set => name = value ?? defaultname;
        }
    }

    class DisllowNullCls
    {
        //The variable could be null in core scenarios, often when first instantiated.
        //The variable shouldn't be explicitly set to null.

        private string? state = null;

        [DisallowNull]
        public string? State
        {
            get => state;
            set => state = value ?? throw new NullReferenceException();
        }
    }

    class MaybeNullCls
    {
        //A non-nullable return value may be null.

        public int? FindUnique(params int[] numbers)
        {
            var dict = new Dictionary<int, int>();
            foreach (var n in numbers)
            {
                if (dict.ContainsKey(n))
                    dict[n]++;
                else
                    dict[n] = 1;
            }

            return dict.Any(x => x.Value == 1)
                ? new int?(dict.First(x => x.Value == 1).Key)
                : null;
        }

        [return: MaybeNull]
        public T FindUnique<T>(params T[] items) where T : notnull
        {
            var dict = new Dictionary<T, int>();
            foreach (var n in items)
            {
                if (dict.ContainsKey(n))
                    dict[n]++;
                else
                    dict[n] = 1;
            }

            return dict.Any(x => x.Value == 1)
                ? dict.First(x => x.Value == 1).Key
                : default;
        }
    }

    class NotNullCls
    {
        //A nullable return value will never be null.

        [return: NotNull]
        public bool? Contains<T>(T item, params T[] items) where T : notnull
        {
            foreach (var n in items)
            {
                if (item.Equals(n))
                    return true;
            }

            return false;
        }
    }

    class NotNullWhenCls
    {
        //A nullable input argument will not be null when the method returns the specified bool value.

        public bool HasRight([NotNullWhen(true)] int? userId)
        {
            return userId == 42;
        }

        public void DoSomething([DisallowNull] int? userid)
        {
            //
        }
    }

    class MaybeNullWhenCls
    {
        //A non-nullable input argument may be null when the method returns the specified bool value.

        public bool HasRight([MaybeNullWhen(false)] int? userId)
        {
            return userId == 42;
        }

        public void DoSomething([DisallowNull] int? userid)
        {
            //
        }
    }

    class NotNullIfNotNullCls
    {
        //A return value isn't null if the input argument for the specified parameter isn't null.

        [return: NotNullIfNotNull("str")]
        public string? ToLower(string? str)
        {
            return str?.ToLower();
        }

        [return: NotNullIfNotNull("str")]
        public string? ToUpper(string? str)
        {
            return str?.ToUpper();
        }

        public void Print(string str)
        {
            // --
        }
    }
}
