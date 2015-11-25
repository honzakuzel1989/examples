using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.Security.Principal;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Cryptography;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace _20_Security
{
    public class Test : IChapter
    {
        #region IChapter Members

        public void Run()
        {
            //.Net utility for security managment is caspol.exe

            //_1();
            //_2();
            //_3();
            //_4();
            //_5(@"c:\Users\a\Downloads\Win CE 5 hry.rar");
            //_6(@"c:\Users\a\Downloads\Win CE 5 hry.rar");
            //_7();
            //_8();
            //_9();
            //_10("release");
            //_11("{0},{1},{2},{3},{4},{5},{6},{7}", 0, 1, 2, 3, 4, 5, 6, 7);
            _12();
        }

        #endregion

        private void _1()
        {
            //Tie .NET security object eith current windows account
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //Access to security object from thread object
            WindowsPrincipal wp = (WindowsPrincipal)Thread.CurrentPrincipal;
            WindowsIdentity wi = (WindowsIdentity)wp.Identity;

            //Get and write security informations
            Console.WriteLine("Name: {0}", wi.Name);
            Console.WriteLine("User? {0}", wp.IsInRole("BUILTIN\\Users"));
            Console.WriteLine("Admin? {0}", wp.IsInRole(WindowsBuiltInRole.Administrator));
            Console.WriteLine("Authenticated: {0}", wi.IsAuthenticated);
            Console.WriteLine("Authenticate type: {0}", wi.AuthenticationType);
            Console.WriteLine("Anonymous: {0}", wi.IsAnonymous);
        }

        private void _2()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            try
            {
                //Check permission using attribute - not working (i don't know why!)
                //ShowMessage();
                //Check permision usin PrincipalPermision class - not working again
                PrincipalPermission pp = new PrincipalPermission(null, "Administrator");
                pp.Demand();
                Console.WriteLine("Class {0}", "Admin message");
            }
            catch (SecurityException se)
            {
                Console.WriteLine("Security exception{0}", se.Message == string.Empty ? "" : " : " + se.Message);
            }
        } 

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        private void ShowMessage()
        {
            Console.WriteLine("Attribute {0}","Admin message");
        }

        byte[] pubKeyBlob;

        private void _3()
        { 
            //Suffix Cng means Cryptography Next Generation
            //Suffix Managed means that the algorithm is implemented in managed code
            //Suffix CryptoServiceProvider means that class implemented abstract base class
            CngKey keys = CreateKeys();
            byte[] data = Encoding.UTF8.GetBytes("Data data");
            byte[] signature = CreateSignature(data, keys);
            Console.WriteLine("Signature:\n{0}", Convert.ToBase64String(signature));

            if(VerifySignaure(keys, data, signature, pubKeyBlob))
            {
                Console.WriteLine("Signature was successfully verified.");
            }
        }


        private CngKey CreateKeys()
        {
            //Create elyptic curve DSA, 256b
            CngKey keys = CngKey.Create(CngAlgorithm.ECDsaP256);
            pubKeyBlob = keys.Export(CngKeyBlobFormat.GenericPublicBlob);
            return keys;
        }

        private byte[] CreateSignature(byte[] data, CngKey key)
        {
            ECDsaCng signingAlg = new ECDsaCng(key);
            byte[] signature = signingAlg.SignData(data);
            signingAlg.Clear();

            return signature;
        }

        private bool VerifySignaure(CngKey key, byte[] data, byte[] signature, byte[] pubkey)
        {
            bool retValue = false;

            using (ECDsaCng signingAlg = new ECDsaCng(key))
            {
                retValue = signingAlg.VerifyData(data, signature);
                signingAlg.Clear();
            }

            return retValue;
        }

        CngKey aliceKey, bobKey;
        byte[] alicePubKeyBlob, bobPubKeyBlob;

        private void _4()
        {
            //Create keys, send a receive
            CreateDHKeys();
            string sendMsg = "Hello Bob, I love you.";
            byte [] data = AliceSendData(sendMsg);
            string recvMsg = BobReceiveData(data);
        }

        private void CreateDHKeys()
        {
            //Crete Eliptic Curve Diffie-Helman keys
            aliceKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);
            bobKey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP256);

            alicePubKeyBlob = aliceKey.Export(CngKeyBlobFormat.GenericPublicBlob);
            bobPubKeyBlob = bobKey.Export(CngKeyBlobFormat.GenericPublicBlob);
        }

        private string BobReceiveData(byte[] data)
        {
            Console.WriteLine("Bob cipher: {0}", Convert.ToBase64String(data));

            AesCryptoServiceProvider acsp = new AesCryptoServiceProvider();
            byte[] rawData = null;

            //Convert bits to bytes
            int nBytes = acsp.BlockSize >> 3;

            //Get initialization vector
            byte[] IV = new byte[nBytes];
            for (int i = 0; i < nBytes; i++)
            {
                IV[i] = data[i];
            }

            //Get bob algorithm (use Bob's keys)
            ECDiffieHellmanCng bobAlgorithm = new ECDiffieHellmanCng(bobKey);

            using (CngKey alicePubKey = CngKey.Import(alicePubKeyBlob, CngKeyBlobFormat.EccPublicBlob))
            {
                //Get together symmetric key
                byte[] symKey = bobAlgorithm.DeriveKeyMaterial(alicePubKey);

                acsp.Key = symKey;
                acsp.IV = IV;

                using(ICryptoTransform decryptor = acsp.CreateDecryptor())
                using (MemoryStream ms = new MemoryStream())
                {
                    //Decryption data
                    CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write);
                    cs.Write(data, nBytes, data.Length - nBytes);
                    cs.Close();

                    rawData = ms.ToArray();
                }
                acsp.Clear();
            }

            string msg = Encoding.UTF8.GetString(rawData);
            Console.WriteLine("Bob message: {0}", msg);
            return msg;
        }

        private byte [] AliceSendData(string message)
        {
            Console.WriteLine("Alice message: {0}", message);

            byte[] rawData = Encoding.UTF8.GetBytes(message);
            byte[] encData = null;

            //Get alice's algorithm (use alice keys)
            ECDiffieHellmanCng aliceAlg = new ECDiffieHellmanCng(aliceKey);
            using (CngKey bobPubKey = CngKey.Import(bobPubKeyBlob, CngKeyBlobFormat.EccPublicBlob))
            {
                //Create symmetric key - using alice's keys and bob's public key
                byte[] symKey = aliceAlg.DeriveKeyMaterial(bobPubKey);

                //Provider for data encryption
                AesCryptoServiceProvider acsp = new AesCryptoServiceProvider();
                acsp.Key = symKey;
                acsp.GenerateIV();

                using(ICryptoTransform encryptor = acsp.CreateEncryptor())
                using (MemoryStream ms = new MemoryStream())
                {
                    //Create crypto stream
                    CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                    //Send initial vector
                    ms.Write(acsp.IV, 0, acsp.IV.Length);
                    //Send encrypted data
                    cs.Write(rawData, 0, rawData.Length);
                    //Important thing!
                    cs.Close();
                    encData = ms.ToArray();
                }
                acsp.Clear();
            }

            Console.WriteLine("Alice cipher: {0}", Convert.ToBase64String(encData));
            return encData;
        }

        private void _5(string filename)
        { 
            //DACL - Discretionary access control list (GetAccessRules)
            //SACL - System access control list (GetAuditRules)
            FileStream fstream = File.Open(filename, FileMode.Open);
            FileSecurity fsecurity = fstream.GetAccessControl();

            //DACL representation
            AuthorizationRuleCollection arl = fsecurity.GetAuditRules(true, true, typeof(NTAccount));
            
            //Show rules
            foreach (AuthorizationRule ar in arl)
            {
                //Acces to the file (this can be various)
                FileSystemAccessRule fsar = ar as FileSystemAccessRule ?? null;
                if (fsar != null)
                {
                    Console.WriteLine("Acces type: {0}", fsar.AccessControlType);
                    Console.WriteLine("Idenity: {0}", fsar.IdentityReference.Value);
                    Console.WriteLine("Rights: {0}", fsar.FileSystemRights);
                }
            }

            fstream.Close();
        }

        private void _6(string filename)
        {
            //Form
            Form f = new Form();
            Button b = new Button();
            b.Text = "Click me, if you can!";
            b.Dock = DockStyle.Fill;
            f.Controls.Add(b);

            try
            {
                //Check if the application has acces to file
                FileIOPermission fileIOPerm = new FileIOPermission(FileIOPermissionAccess.AllAccess, filename);
                fileIOPerm.Demand();
            }
            catch (SecurityException)
            {
                b.Enabled = false;

                //SecurityException.TagretSite is a reference to the method, that this exception raised
            }

            f.ShowDialog();
        }

        private void _7()
        {
            C.methodC();
        }

        public class C
        { 
            //For (security) attributes not possible catch exceptions
            [FileIOPermission(SecurityAction.Demand, Read="C:/")]
            public static void methodC()
            {
                Console.WriteLine("Secure method.");
            }
        }

        private void _8()
        {
            CodeAccessPermission cap = new FileIOPermission(FileIOPermissionAccess.AllAccess, @"C:\");
            //Deny permission
            cap.Deny();
            //Call untrusted method
            UntrustedMethod();
            //Revert ALL permition
            CodeAccessPermission.RevertDeny();
        }

        private void UntrustedMethod()
        {
            FileStream f = null;

            try
            {
                File.Open(@"c:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\x64\WCA.exe.config", FileMode.Open);
            }
            catch (SecurityException se)
            {
                Console.WriteLine("Security exception: {0}", se.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
            finally
            {
                if(f != null) f.Close();
            }
        }

        private void _9()
        {
            CodeAccessPermission perm = new FileIOPermission(FileIOPermissionAccess.Append, @"e:\Progr\C#\ProgramujemeProfesionalne\20-Security\audit.txt");
            
            //Deny permissions
            perm.Deny();
            AuditMethod("Testovaci zapis\n");

            //Revert ALL deny permissions
            CodeAccessPermission.RevertDeny();
        }

        private void AuditMethod(string msg)
        {
            try
            {
                string path = @"e:\Progr\C#\ProgramujemeProfesionalne\20-Security\audit.txt";
                //Get permissions
                FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Append, path);
                //Without line below is occured exception!
                perm.Assert();

                //Write to the file
                using (FileStream fs = new FileStream(path, FileMode.Append))
                {
                    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(msg);

                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();
                    fs.Close();
                    { }
                }

                //Revert ALL assert permissions
                CodeAccessPermission.RevertAssert();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void _10(string opt)
        { 
            //This is not connected with security!

            switch (opt)
            {
                case "test": Console.WriteLine("Test"); break;
                case "debug": Console.WriteLine("Debug"); break;
                case "release": Console.WriteLine("Release"); break;
                default: Console.WriteLine("Default"); break;
            }
        }

        private void _11(string str, params Object[] prms)
        {
            //This is not connected with security!
            //This princip is use in string.Format

            Console.WriteLine(str, prms);
        }

        //NH = -100
        //NT = -10
        //Z = 0
        //PT = 10
        //PH = 100
        private enum Axis {NH=-100, NNN, NT=-10, Z=0, PT=10, PH=100, POH};

        private void _12()
        {
            //This is not connected with security!
            //In C# is enum mapped to the integer

            object[] axisVal = new object[] { Axis.NH, Axis.NNN, Axis.NT, Axis.Z, Axis.PT, Axis.PH, Axis.POH };
            foreach(Axis s in axisVal) Console.WriteLine((int)s);
        }

        private void _13()
        { 
            //This is not connected with a security.

            //This is possible only with a declaration
            int[] numbers = { 1, 2, 3, 4, 5 };

            numbers = new int[] { 1, 2, 3, 4, 5, 6 };

            //Three dimensional array of RGB values - 1024 x 724 resolution
            byte[, ,] pixels = new byte[1024, 768, 3];
            //Blue
            pixels[0, 0, 0] = 0;
            pixels[0, 0, 1] = 0;
            pixels[0, 0, 2] = 255;
            //...

            //Length – Total number of elements, across all dimensions of the array
            //Rank – Number of dimensions in the array

            //C# Sorting method = Unstable QuickSort
            //C# Search method in sorted array = BinarySearch
        }
    }
}
