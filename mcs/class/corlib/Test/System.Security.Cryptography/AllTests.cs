//
// TestSuite.System.Security.Cryptography.AllTests.cs
//
// Author:
//      Thomas Neidhart (tome@sbox.tugraz.at)
//	Sebastien Pouliot (spouliot@motus.com)
//
// Portions (C) 2002 Motus Technologies Inc. (http://www.motus.com)
//

using System;
using System.Security.Cryptography;
using NUnit.Framework;

namespace MonoTests.System.Security.Cryptography {
        /// <summary>
        ///   Combines all available crypto unit tests into one test suite.
        /// </summary>
        public class AllTests : TestCase {
                public AllTests(string name) : base(name) {}
                
        	// because most crypto stuff works with byte[] buffers
        	static public void AssertEquals (string msg, byte[] array1, byte[] array2)
        	{
        		if ((array1 == null) && (array2 == null))
        			return;
        		if (array1 == null)
        			Fail (msg + " -> First array is NULL");
        		if (array2 == null)
        			Fail (msg + " -> Second array is NULL");
        
        		bool a = (array1.Length == array2.Length);
        		if (a) {
        			for (int i = 0; i < array1.Length; i++) {
        				if (array1 [i] != array2 [i]) {
        					a = false;
        					break;
        				}
        			}
        		}
        		msg += " -> Expected " + BitConverter.ToString (array1, 0);
        		msg += " is different than " + BitConverter.ToString (array2, 0);
        		Assert (msg, a);
        	}

		public static byte[] dsaG = { 0x3D, 0x4F, 0xCC, 0x78, 0x6A, 0x7A, 0x23, 0xF1, 0x41, 0x76, 0xEB, 0xB0, 0x0F, 0xD5, 0x0F, 0x78, 0x21, 0x73, 0x83, 0xC2, 0x1B, 0xF4, 0x7E, 0x68, 0xB2, 0x4B,
						    0xB9, 0x9D, 0x3F, 0x00, 0x84, 0x74, 0xD8, 0xF3, 0x31, 0xAA, 0x7A, 0xDB, 0xAF, 0x1E, 0x1C, 0x5B, 0x11, 0x2B, 0x78, 0x94, 0xBC, 0xFC, 0x69, 0x7C, 0xD7, 
						    0xD2, 0x82, 0x22, 0x32, 0xCB, 0xAC, 0x06, 0xBE, 0x84, 0xFD, 0xA0, 0x5D, 0xA2, 0x80, 0x48, 0xDF, 0xA7, 0xC7, 0xC1, 0x6F, 0x16, 0x9D, 0xD0, 0xA6, 0xC2, 
						    0x40, 0x75, 0x92, 0xFE, 0xE6, 0x85, 0x12, 0x01, 0xE3, 0x7D, 0x36, 0x52, 0xB7, 0xEF, 0x0B, 0x62, 0x96, 0x42, 0xE0, 0x72, 0xA5, 0xF9, 0x74, 0xFB, 0xE6, 
						    0xB5, 0xC2, 0x10, 0x4C, 0x0A, 0x1E, 0x55, 0x4C, 0x96, 0x07, 0xD6, 0xC0, 0x64, 0x14, 0x86, 0x95, 0x35, 0xE5, 0x1B, 0xB7, 0x94, 0x3A, 0xFD, 0x47, 0x62, 
						    0x65, 0x56 };
		public static byte[] dsaJ = { 0x00, 0x00, 0x00, 0x01, 0x0E, 0x8B, 0x4A, 0xE4, 0x62, 0x61, 0xDB, 0x28, 0x71, 0x9E, 0xAB, 0x83, 0x2A, 0x88, 0x3A, 0x91, 0x35, 0xFE, 0xE0, 0x8E, 0xD4, 0xF7,
						    0xC4, 0x9F, 0xBE, 0x7C, 0x2E, 0x0D, 0x95, 0x5B, 0xA3, 0x87, 0x25, 0x36, 0x07, 0x34, 0x2D, 0xF4, 0xB3, 0x48, 0x12, 0x4C, 0x6F, 0xC9, 0xB7, 0x7A, 0x07, 
						    0x61, 0x7F, 0x92, 0xF2, 0xFA, 0xED, 0x35, 0x86, 0xFC, 0x91, 0x12, 0x7F, 0x8A, 0x98, 0x1C, 0xA1, 0xF1, 0xAA, 0xD9, 0x0A, 0x3F, 0x71, 0x82, 0x8F, 0xED, 
						    0x15, 0xF6, 0x2B, 0xA1, 0x09, 0xC1, 0x27, 0xD6, 0x22, 0x78, 0x6C, 0x34, 0xCA, 0xF5, 0x26, 0x6C, 0xEE, 0x2B, 0x49, 0x54, 0x2A, 0x45, 0xD7, 0x5D, 0x5A, 
						    0x35, 0xE5, 0xF2, 0xFC, 0x3B, 0x6F, 0xF5, 0xEA, 0xE1, 0x16, 0x32 };
		public static byte[] dsaP = { 0xB3, 0xF3, 0x9C, 0xD2, 0xDE, 0x20, 0x8F, 0x43, 0x51, 0xAA, 0x40, 0x8A, 0x8B, 0x8C, 0xA7, 0x26, 0x73, 0x80, 0x12, 0xE9, 0x0D, 0x86, 0x39, 0x07, 0x24, 0xF3,
						    0xB3, 0x36, 0xC1, 0xCF, 0xEB, 0xD9, 0x32, 0x1C, 0xC5, 0x30, 0x67, 0x70, 0x33, 0x3A, 0x42, 0xC6, 0x60, 0xE5, 0xA5, 0x3A, 0x8D, 0xB3, 0x95, 0x82, 0xB3, 
						    0x49, 0xB6, 0x72, 0x80, 0x30, 0xC8, 0xE5, 0xD0, 0x96, 0x03, 0x98, 0x10, 0x17, 0x66, 0x46, 0x1C, 0x45, 0x25, 0x58, 0x93, 0x20, 0x53, 0x21, 0xE6, 0x93, 
						    0x26, 0xCE, 0x8B, 0x8E, 0x1C, 0xC8, 0x76, 0x97, 0xF7, 0x27, 0x86, 0x7D, 0xB9, 0xE8, 0x73, 0x7C, 0x45, 0xF6, 0xC6, 0x20, 0x90, 0x0D, 0xEF, 0x3D, 0x46, 
						    0x5A, 0x26, 0xE6, 0x0C, 0x3A, 0xC0, 0x69, 0xDE, 0x9C, 0x8F, 0x75, 0xE3, 0x7C, 0xFE, 0x62, 0xD4, 0xF2, 0x7D, 0x22, 0xBD, 0x44, 0x72, 0x3F, 0xED, 0xC6, 
						    0x7B, 0xD3 };
		public static byte[] dsaQ = { 0xAA, 0x47, 0x13, 0x5B, 0xE0, 0x9E, 0xD0, 0xBE, 0x64, 0xF0, 0xE1, 0x93, 0x50, 0xC9, 0x11, 0xA0, 0x62, 0x83, 0x73, 0x51 };
		public static byte[] dsaX = { 0x7C, 0x03, 0xB2, 0xB5, 0x9B, 0x6D, 0x51, 0x91, 0x73, 0xB7, 0xF0, 0x2F, 0xC1, 0x18, 0xA7, 0x9A, 0xF6, 0x0A, 0x2F, 0xB1 };
		public static byte[] dsaY = { 0xB2, 0x12, 0x51, 0x51, 0xD1, 0xB1, 0x11, 0x8C, 0x52, 0x28, 0xCE, 0x49, 0x56, 0x89, 0x7D, 0x1C, 0x07, 0x50, 0xC0, 0x82, 0xBE, 0xC0, 0x5F, 0x57, 0xE2, 0x7F,
						    0x52, 0x00, 0x3F, 0xBE, 0xBD, 0xF6, 0x4E, 0x30, 0xE6, 0x22, 0xF8, 0xCD, 0x72, 0xBA, 0xF4, 0x00, 0x95, 0x0B, 0xE7, 0x4A, 0x54, 0xD3, 0x5A, 0xBE, 0xC2, 
						    0x64, 0xF4, 0x55, 0x00, 0x80, 0x8B, 0x80, 0x30, 0x5B, 0xAA, 0x2F, 0x62, 0x37, 0xE2, 0x1D, 0xEB, 0x47, 0x1C, 0x27, 0xE8, 0x70, 0xDE, 0x91, 0x83, 0x7C, 
						    0xBA, 0x49, 0xEC, 0x87, 0x45, 0x3E, 0xCC, 0xC9, 0x11, 0xE5, 0x0E, 0xF9, 0x26, 0x41, 0xC1, 0xFF, 0x27, 0x8C, 0x65, 0xD4, 0x2E, 0xA4, 0x8E, 0x0E, 0xCF, 
						    0xCD, 0x4D, 0xC8, 0xA2, 0x5F, 0xB1, 0x34, 0xEE, 0xB9, 0xBE, 0x29, 0xF9, 0x71, 0x14, 0xE8, 0x34, 0xAA, 0xD5, 0x80, 0x86, 0x66, 0x0B, 0xC4, 0x89, 0x03, 
						    0xC7, 0xBB };
		public static int dsaCounter = 224;
		public static byte[] dsaSeed = { 0xB9, 0x83, 0x39, 0x6F, 0x6D, 0x25, 0xBA, 0xF6, 0xEE, 0xC9, 0xEB, 0xE2, 0xF5, 0x35, 0xC7, 0xC1, 0xE9, 0x1B, 0xAF, 0x9B };

		static public DSAParameters GetKey (bool includePrivateKey) 
		{
			DSAParameters p = new DSAParameters();
			p.Counter = dsaCounter;
			p.G = (byte[]) dsaG.Clone ();
			p.J = (byte[]) dsaJ.Clone ();
			p.P = (byte[]) dsaP.Clone ();
			p.Q = (byte[]) dsaQ.Clone ();
			p.Seed = (byte[]) dsaSeed.Clone ();
			p.Y = (byte[]) dsaY.Clone ();
			if (includePrivateKey)
				p.X = (byte[]) dsaX.Clone ();
			else
				p.X = null;
			return p;
		}

		static byte[] rsaModulus =  { 0xbb, 0xf8, 0x2f, 0x09, 0x06, 0x82, 0xce, 0x9c, 0x23, 0x38, 0xac, 0x2b, 0x9d, 0xa8, 0x71, 0xf7, 
			0x36, 0x8d, 0x07, 0xee, 0xd4, 0x10, 0x43, 0xa4, 0x40, 0xd6, 0xb6, 0xf0, 0x74, 0x54, 0xf5, 0x1f,
			0xb8, 0xdf, 0xba, 0xaf, 0x03, 0x5c, 0x02, 0xab, 0x61, 0xea, 0x48, 0xce, 0xeb, 0x6f, 0xcd, 0x48,
			0x76, 0xed, 0x52, 0x0d, 0x60, 0xe1, 0xec, 0x46, 0x19, 0x71, 0x9d, 0x8a, 0x5b, 0x8b, 0x80, 0x7f,
			0xaf, 0xb8, 0xe0, 0xa3, 0xdf, 0xc7, 0x37, 0x72, 0x3e, 0xe6, 0xb4, 0xb7, 0xd9, 0x3a, 0x25, 0x84,
			0xee, 0x6a, 0x64, 0x9d, 0x06, 0x09, 0x53, 0x74, 0x88, 0x34, 0xb2, 0x45, 0x45, 0x98, 0x39, 0x4e,
			0xe0, 0xaa, 0xb1, 0x2d, 0x7b, 0x61, 0xa5, 0x1f, 0x52, 0x7a, 0x9a, 0x41, 0xf6, 0xc1, 0x68, 0x7f,
			0xe2, 0x53, 0x72, 0x98, 0xca, 0x2a, 0x8f, 0x59, 0x46, 0xf8, 0xe5, 0xfd, 0x09, 0x1d, 0xbd, 0xcb };
		static byte[] rsaExponent = { 0x11 };
		static byte[] rsaP =  { 0xee, 0xcf, 0xae, 0x81, 0xb1, 0xb9, 0xb3, 0xc9, 0x08, 0x81, 0x0b, 0x10, 0xa1, 0xb5, 0x60, 0x01, 
			0x99, 0xeb, 0x9f, 0x44, 0xae, 0xf4, 0xfd, 0xa4, 0x93, 0xb8, 0x1a, 0x9e, 0x3d, 0x84, 0xf6, 0x32,
			0x12, 0x4e, 0xf0, 0x23, 0x6e, 0x5d, 0x1e, 0x3b, 0x7e, 0x28, 0xfa, 0xe7, 0xaa, 0x04, 0x0a, 0x2d,
			0x5b, 0x25, 0x21, 0x76, 0x45, 0x9d, 0x1f, 0x39, 0x75, 0x41, 0xba, 0x2a, 0x58, 0xfb, 0x65, 0x99 };
		static byte[] rsaQ =  { 0xc9, 0x7f, 0xb1, 0xf0, 0x27, 0xf4, 0x53, 0xf6, 0x34, 0x12, 0x33, 0xea, 0xaa, 0xd1, 0xd9, 0x35,
			0x3f, 0x6c, 0x42, 0xd0, 0x88, 0x66, 0xb1, 0xd0, 0x5a, 0x0f, 0x20, 0x35, 0x02, 0x8b, 0x9d, 0x86, 
			0x98, 0x40, 0xb4, 0x16, 0x66, 0xb4, 0x2e, 0x92, 0xea, 0x0d, 0xa3, 0xb4, 0x32, 0x04, 0xb5, 0xcf,
			0xce, 0x33, 0x52, 0x52, 0x4d, 0x04, 0x16, 0xa5, 0xa4, 0x41, 0xe7, 0x00, 0xaf, 0x46, 0x15, 0x03 };
		static byte[] rsaDP = { 0x54, 0x49, 0x4c, 0xa6, 0x3e, 0xba, 0x03, 0x37, 0xe4, 0xe2, 0x40, 0x23, 0xfc, 0xd6, 0x9a, 0x5a, 
			0xeb, 0x07, 0xdd, 0xdc, 0x01, 0x83, 0xa4, 0xd0, 0xac, 0x9b, 0x54, 0xb0, 0x51, 0xf2, 0xb1, 0x3e, 
			0xd9, 0x49, 0x09, 0x75, 0xea, 0xb7, 0x74, 0x14, 0xff, 0x59, 0xc1, 0xf7, 0x69, 0x2e, 0x9a, 0x2e, 
			0x20, 0x2b, 0x38, 0xfc, 0x91, 0x0a, 0x47, 0x41, 0x74, 0xad, 0xc9, 0x3c, 0x1f, 0x67, 0xc9, 0x81 };
		static byte[] rsaDQ = { 0x47, 0x1e, 0x02, 0x90, 0xff, 0x0a, 0xf0, 0x75, 0x03, 0x51, 0xb7, 0xf8, 0x78, 0x86, 0x4c, 0xa9, 
			0x61, 0xad, 0xbd, 0x3a, 0x8a, 0x7e, 0x99, 0x1c, 0x5c, 0x05, 0x56, 0xa9, 0x4c, 0x31, 0x46, 0xa7, 
			0xf9, 0x80, 0x3f, 0x8f, 0x6f, 0x8a, 0xe3, 0x42, 0xe9, 0x31, 0xfd, 0x8a, 0xe4, 0x7a, 0x22, 0x0d, 
			0x1b, 0x99, 0xa4, 0x95, 0x84, 0x98, 0x07, 0xfe, 0x39, 0xf9, 0x24, 0x5a, 0x98, 0x36, 0xda, 0x3d };
		static byte[] rsaInverseQ = { 0xb0, 0x6c, 0x4f, 0xda, 0xbb, 0x63, 0x01, 0x19, 0x8d, 0x26, 0x5b, 0xdb, 0xae, 0x94, 0x23, 0xb3, 
			0x80, 0xf2, 0x71, 0xf7, 0x34, 0x53, 0x88, 0x50, 0x93, 0x07, 0x7f, 0xcd, 0x39, 0xe2, 0x11, 0x9f, 
			0xc9, 0x86, 0x32, 0x15, 0x4f, 0x58, 0x83, 0xb1, 0x67, 0xa9, 0x67, 0xbf, 0x40, 0x2b, 0x4e, 0x9e, 
			0x2e, 0x0f, 0x96, 0x56, 0xe6, 0x98, 0xea, 0x36, 0x66, 0xed, 0xfb, 0x25, 0x79, 0x80, 0x39, 0xf7 };
		static byte[] rsaD = { 0xa5, 0xda, 0xfc, 0x53, 0x41, 0xfa, 0xf2, 0x89, 0xc4, 0xb9, 0x88, 0xdb, 0x30, 0xc1, 0xcd, 0xf8,
			0x3f, 0x31, 0x25, 0x1e, 0x06, 0x68, 0xb4, 0x27, 0x84, 0x81, 0x38, 0x01, 0x57, 0x96, 0x41, 0xb2, 
			0x94, 0x10, 0xb3, 0xc7, 0x99, 0x8d, 0x6b, 0xc4, 0x65, 0x74, 0x5e, 0x5c, 0x39, 0x26, 0x69, 0xd6, 
			0x87, 0x0d, 0xa2, 0xc0, 0x82, 0xa9, 0x39, 0xe3, 0x7f, 0xdc, 0xb8, 0x2e, 0xc9, 0x3e, 0xda, 0xc9, 
			0x7f, 0xf3, 0xad, 0x59, 0x50, 0xac, 0xcf, 0xbc, 0x11, 0x1c, 0x76, 0xf1, 0xa9, 0x52, 0x94, 0x44, 
			0xe5, 0x6a, 0xaf, 0x68, 0xc5, 0x6c, 0x09, 0x2c, 0xd3, 0x8d, 0xc3, 0xbe, 0xf5, 0xd2, 0x0a, 0x93,
			0x99, 0x26, 0xed, 0x4f, 0x74, 0xa1, 0x3e, 0xdd, 0xfb, 0xe1, 0xa1, 0xce, 0xcc, 0x48, 0x94, 0xaf, 
			0x94, 0x28, 0xc2, 0xb7, 0xb8, 0x88, 0x3f, 0xe4, 0x46, 0x3a, 0x4b, 0xc8, 0x5b, 0x1c, 0xb3, 0xc1 };

		static public RSAParameters GetRsaKey (bool includePrivateKey) 
		{
			RSAParameters p = new RSAParameters();
			if (includePrivateKey) {
				p.D = (byte[]) rsaD.Clone();
				p.DP = (byte[]) rsaDP.Clone();
				p.DQ = (byte[]) rsaDQ.Clone();
				p.P = (byte[]) rsaP.Clone();
				p.Q = (byte[]) rsaQ.Clone();
				p.InverseQ = (byte[]) rsaInverseQ.Clone();
			}
			else {
				p.D = null;
				p.DP = null;
				p.DQ = null;
				p.P = null;
				p.Q = null;
				p.InverseQ = null;
			}
			p.Modulus = (byte[]) rsaModulus.Clone();
			p.Exponent = (byte[]) rsaExponent.Clone();
			return p;
		}

                public static ITest Suite 
                { 
                        get 
                        {
                                TestSuite suite =  new TestSuite ();
                                suite.AddTest (SymmetricAlgorithmTest.Suite);
				suite.AddTest (AsymmetricAlgorithmTest.Suite); 
                        	suite.AddTest (RNGCryptoServiceProviderTest.Suite);
				suite.AddTest (FromBase64TransformTest.Suite);
				suite.AddTest (RijndaelManagedTest.Suite);
				suite.AddTest (MD5Test.Suite);
				suite.AddTest (RC2Test.Suite);
				suite.AddTest (CryptoConfigTest.Suite);
				suite.AddTest (DSATest.Suite);
				suite.AddTest (DSACryptoServiceProviderTest.Suite);
				suite.AddTest (DSASignatureDeformatterTest.Suite);
				suite.AddTest (DSASignatureFormatterTest.Suite);
				suite.AddTest (RSATest.Suite);
                                suite.AddTest (RandomNumberGeneratorTest.Suite);
                                suite.AddTest (HashAlgorithmTest.Suite);
                                suite.AddTest (SHA1Test.Suite);
                                suite.AddTest (SHA1CryptoServiceProviderTest.Suite);
				suite.AddTest (KeyedHashAlgorithmTest.Suite);
				suite.AddTest (HMACSHA1Test.Suite);
				suite.AddTest (PKCS1MaskGenerationMethodTest.Suite);
				suite.AddTest (RijndaelTest.Suite);
				suite.AddTest (PasswordDeriveBytesTest.Suite);
				suite.AddTest (SHA256Test.Suite);
				suite.AddTest (SHA256ManagedTest.Suite);
				suite.AddTest (SHA384Test.Suite);
				suite.AddTest (SHA384ManagedTest.Suite);
				suite.AddTest (SHA512Test.Suite);
				suite.AddTest (SHA512ManagedTest.Suite);
				suite.AddTest (SignatureDescriptionTest.Suite);
				suite.AddTest (RSACryptoServiceProviderTest.Suite);
				suite.AddTest (RSAOAEPKeyExchangeDeformatterTest.Suite);
				suite.AddTest (RSAOAEPKeyExchangeFormatterTest.Suite);
				suite.AddTest (RSAPKCS1KeyExchangeDeformatterTest.Suite);
				suite.AddTest (RSAPKCS1KeyExchangeFormatterTest.Suite);
				suite.AddTest (RSAPKCS1SignatureDeformatterTest.Suite);
				suite.AddTest (RSAPKCS1SignatureFormatterTest.Suite);
                                return suite;
                        }
                }
        }
}
