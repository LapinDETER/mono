//
// RSAPKCS1SignatureDeformatterTest.cs - NUnit tests for PKCS#1 v.1.5 signature.
//
// Author:
//	Sebastien Pouliot (spouliot@motus.com)
//
// (C) 2002 Motus Technologies Inc. (http://www.motus.com)
//

using NUnit.Framework;
using System;
using System.Security.Cryptography;

namespace MonoTests.System.Security.Cryptography {

public class RSAPKCS1SignatureDeformatterTest : TestCase {

	public RSAPKCS1SignatureDeformatterTest () : base ("System.Security.Cryptography.RSAPKCS1SignatureDeformatter testsuite") {}
	public RSAPKCS1SignatureDeformatterTest (string name) : base(name) {}

	protected override void SetUp () {}

	protected override void TearDown () {}

	public static ITest Suite {
		get {
			return new TestSuite (typeof (RSAPKCS1SignatureDeformatterTest));
		}
	}

	public void AssertEquals (string msg, byte[] array1, byte[] array2) 
	{
		AllTests.AssertEquals (msg, array1, array2);
	}

	public void TestConstructors () 
	{
		RSAPKCS1SignatureDeformatter fmt;
		fmt = new RSAPKCS1SignatureDeformatter ();
		AssertNotNull ("RSAPKCS1SignatureDeformatter()", fmt);

		fmt = new RSAPKCS1SignatureDeformatter (null);
		AssertNotNull ("RSAPKCS1SignatureDeformatter(null)", fmt);

		RSA rsa = RSA.Create ();
		fmt = new RSAPKCS1SignatureDeformatter (rsa);
		AssertNotNull ("RSAPKCS1SignatureDeformatter(rsa)", fmt);

		DSA dsa = DSA.Create ();
		try {
			fmt = new RSAPKCS1SignatureDeformatter (dsa);
			Fail ("Expected InvalidCastException but got none");
		}
		catch (InvalidCastException) {
			// do nothing, this is what we expect
		}
		catch (Exception e) {
			Fail ("Expected InvalidCastException but got: " + e.ToString ());
		}
	}

	public void TestSetKey () 
	{
		RSAPKCS1SignatureDeformatter fmt;
		fmt = new RSAPKCS1SignatureDeformatter ();
		try {
			fmt.SetKey (RSA.Create ());
		}
		catch (Exception e) {
			Fail ("Unexpected exception: " + e.ToString ());
		}

		try {
			fmt.SetKey (DSA.Create ());
			Fail ("Expected InvalidCastException but got none");
		}
		catch (InvalidCastException) {
			// do nothing, this is what we expect
		}
		catch (Exception e) {
			Fail ("Expected InvalidCastException but got: " + e.ToString ());
		}

		try {
			fmt.SetKey (null);
		}
		catch (Exception e) {
			Fail ("Expected ArgumentNullException but got: " + e.ToString ());
		}
	}

	public void TestSetHashAlgorithm () 
	{
		RSAPKCS1SignatureDeformatter fmt;
		fmt = new RSAPKCS1SignatureDeformatter ();

		try {
			fmt.SetHashAlgorithm ("SHA1");
		}
		catch (Exception e) {
			Fail ("Unexpected exception: " + e.ToString ());
		}

		try {
			fmt.SetHashAlgorithm ("MD5");
		}
		catch (Exception e) {
			Fail ("Unexpected exception: " + e.ToString ());
		}

		try {
			fmt.SetHashAlgorithm ("SHA256");
		}
		catch (Exception e) {
			Fail ("Unexpected exception: " + e.ToString ());
		}

		try {
			fmt.SetHashAlgorithm ("SHA384");
		}
		catch (Exception e) {
			Fail ("Unexpected exception: " + e.ToString ());
		}

		try {
			fmt.SetHashAlgorithm ("SHA512");
		}
		catch (Exception e) {
			Fail ("Unexpected exception: " + e.ToString ());
		}
	}

	public void TestVerifySignature () 
	{
		RSAPKCS1SignatureDeformatter fmt = new RSAPKCS1SignatureDeformatter ();

		// no hash algorithm
		byte[] hash = new byte [1];
		byte[] signature = new byte [1];
		try {
			fmt.VerifySignature (hash, signature);
			Fail ("VerifySignature(?) no hash algo - Expected CryptographicUnexpectedOperationException but none");
		}
		catch (CryptographicUnexpectedOperationException) {
			// this was expected
		}
		catch (Exception e) {
			Fail ("VerifySignature(?) no hash algo - Expected CryptographicUnexpectedOperationException but got: " + e.ToString ());
		}

		// no key
		fmt.SetHashAlgorithm ("SHA1");
		hash = new byte [20];
		try {
			fmt.VerifySignature (hash, signature);
			Fail ("VerifySignature(?) no key - Expected CryptographicUnexpectedOperationException but none");
		}
		catch (CryptographicUnexpectedOperationException) {
			// this was expected
		}
		catch (Exception e) {
			Fail ("VerifySignature(?) no key - Expected CryptographicUnexpectedOperationException but got: " + e.ToString ());
		}

		// no need for the private key 
		RSA rsa = RSA.Create ();
		rsa.ImportParameters (AllTests.GetRsaKey (false));
		fmt.SetKey (rsa);

		// good SHA1
		fmt.SetHashAlgorithm ("SHA1");
		hash = new byte [20];
		byte[] shaSignature = { 0x51, 0xE1, 0x69, 0xC4, 0x84, 0x0C, 0x33, 0xD9, 0x80, 0xC0, 0xBD, 0x85, 0x87, 0x6E, 0x85, 0x91, 0xB9, 0xD5, 0xB6, 0xE1, 0xAB, 0xD3, 0x06, 0x83, 0xCF, 0x33, 0x56, 0xB9, 0xE6, 0x2C, 0x37, 0xC0, 0x08, 0xFC, 0x81, 0x15, 0xAB, 0x57, 0x80, 0xE4, 0xB9, 0x95, 0x4B, 0xFA, 0x63, 0x13, 0x5E, 0xA9, 0x6E, 0xAB, 0xB0, 0x89, 0xF3, 0xD0, 0xE9, 0xC7, 0xE7, 0xA0, 0xE2, 0xB6, 0x0A, 0xFF, 0x46, 0x2B, 0x8B, 0xC1, 0x4C, 0xEA, 0xDB, 0xEA, 0xD6, 0xF5, 0xA5, 0x2C, 0x8C, 0x1D, 0x57, 0xDF, 0x2D, 0xF0, 0x6B, 0x1D, 0xA9, 0xAE, 0x7F, 0x10, 0x02, 0xE2, 0x05, 0x7E, 0xD2, 0x80, 0xFC, 0x0E, 0x5A, 0xFD, 0xE9, 0xDB, 0x1B, 0xBA, 0xB4, 0xF7, 0x50, 0x88, 0x73, 0x95, 0xBD, 0x3C, 0xCB, 0x33, 0x02, 0xF5, 0x55, 0x10, 0xA6, 0x1B, 0xFD, 0x1D, 0xB1, 0x0E, 0xE3, 0xD0, 0xB7, 0x14, 0x8D, 0x45, 0xC4, 0xF3 };
		Assert ("VerifySignature(SHA1, sign)", fmt.VerifySignature (hash, shaSignature));

		// bad signature
		shaSignature [0] = (byte) ~shaSignature [0];
		Assert ("VerifySignature(SHA1, badSign)", !fmt.VerifySignature (hash, shaSignature));

		// wrong SHA1 length
		hash = new byte [19];
		try {
			fmt.VerifySignature (hash, shaSignature);
			Fail ("VerifySignature(badSHA1, sign) - Should have thrown an CryptographicException");
		}
		catch (CryptographicException) {
			// this is expected (invalid hash length)
		}
		catch (Exception e) {
			Fail ("VerifySignature(badSHA1, sign) - Unexpected exception: " + e.ToString ());
		}
		
		// wrong signature length
		hash = new byte [20];
		shaSignature = new byte [shaSignature.Length-1];
		Assert ("VerifySignature(SHA1, badSign)", !fmt.VerifySignature (hash, shaSignature));

		// good MD5
		fmt.SetHashAlgorithm ("MD5");
		hash = new byte [16];
		byte[] md5Signature = { 0xB4, 0xA9, 0xE9, 0x76, 0x04, 0x0E, 0x0E, 0x04, 0xA3, 0x68, 0x9E, 0x50, 0xD1, 0x29, 0x07, 0x22, 0x45, 0x41, 0x72, 0x1F, 0xBE, 0x74, 0x78, 0xDA, 0x5F, 0x22, 0x4B, 0x45, 0xA8, 0x5F, 0x2D, 0xA5, 0x5F, 0x01, 0x84, 0xA7, 0xF3, 0x6E, 0xB8, 0x8B, 0xF3, 0x29, 0xB2, 0x82, 0xE6, 0x5D, 0x1A, 0x98, 0xAE, 0x9C, 0x2E, 0xB0, 0xDD, 0x3F, 0x8D, 0xF9, 0x1C, 0x9E, 0x40, 0x25, 0x01, 0x9F, 0x92, 0x4E, 0xBE, 0x11, 0xE5, 0xE8, 0xE0, 0xF6, 0x3E, 0xDF, 0x8D, 0x1A, 0xC7, 0x26, 0x37, 0xF7, 0x01, 0x95, 0x48, 0xD8, 0x07, 0x4D, 0x0E, 0xDE, 0xB2, 0x76, 0xD1, 0x23, 0xBD, 0x74, 0xE9, 0xC3, 0x63, 0xB3, 0xE7, 0xCE, 0xA2, 0xEA, 0x20, 0x19, 0x1C, 0x4D, 0x8D, 0xBB, 0xAB, 0x6E, 0xB0, 0xD0, 0x08, 0xC2, 0x2B, 0x69, 0xA4, 0xF3, 0xE9, 0x23, 0xAC, 0x93, 0xB2, 0x0F, 0x90, 0x95, 0x6A, 0x66, 0xDC, 0x44 };
		Assert ("VerifySignature(MD5, sign)", fmt.VerifySignature (hash, md5Signature));

		// bad signature
		md5Signature [0] = (byte) ~md5Signature [0];
		Assert ("VerifySignature(MD5, badSign)", !fmt.VerifySignature (hash, md5Signature));

		// wrong MD5 length
		hash = new byte [17];
		try {
			fmt.VerifySignature (hash, md5Signature);
			Fail ("VerifySignature(badMD5, sign) - Should have thrown an CryptographicException");
		}
		catch (CryptographicException) {
			// this is expected (invalid hash length)
		}
		catch (Exception e) {
			Fail ("VerifySignature(badMD5, sign) - Unexpected exception: " + e.ToString ());
		}
		
		// wrong signature length
		hash = new byte [16];
		md5Signature = new byte [md5Signature.Length-1];
		Assert ("VerifySignature(MD5, badSign)", !fmt.VerifySignature (hash, md5Signature));
	}

	public void TestVerifySignatureHash () 
	{
		RSAPKCS1SignatureDeformatter fmt = new RSAPKCS1SignatureDeformatter ();
		HashAlgorithm hash = null;
		byte[] data = new byte [20];

		// no hash algorithm
		byte[] signature = new byte [1];
		try {
			fmt.VerifySignature (hash, signature);
			Fail ("VerifySignature(?) no hash - Expected ArgumentNullException but none");
		}
		catch (ArgumentNullException) {
			// this was expected
		}
		catch (Exception e) {
			Fail ("VerifySignature(?) no hash - Expected ArgumentNullException but got: " + e.ToString ());
		}

		// no key
		hash = SHA1.Create ();
		try {
			fmt.VerifySignature (hash, signature);
			Fail ("VerifySignature(?) no key - Expected CryptographicUnexpectedOperationException but none");
		}
		catch (CryptographicUnexpectedOperationException) {
			// this was expected
		}
		catch (Exception e) {
			Fail ("VerifySignature(?) no key - Expected CryptographicUnexpectedOperationException but got: " + e.ToString ());
		}

		// no need for the private key 
		RSA rsa = RSA.Create ();
		rsa.ImportParameters (AllTests.GetRsaKey (false));
		fmt.SetKey (rsa);

		// good SHA1
		fmt.SetHashAlgorithm ("SHA1");
		hash = SHA1.Create ();
		hash.ComputeHash (data);
		byte[] shaSignature = { 0x7C, 0xA0, 0x13, 0xFB, 0xCB, 0x4D, 0x08, 0x02, 0x3C, 0x6B, 0x88, 0xA6, 0x25, 0x43, 0x17, 0x51, 0xA6, 0xA8, 0x8F, 0x5B, 0xAE, 0xC3, 0x57, 0x75, 0x2A, 0x8B, 0xD8, 0xBA, 0xCF, 0x9B, 0xBB, 0x5A, 0xD5, 0xB0, 0x11, 0xF2, 0xA9, 0xCC, 0xB5, 0x22, 0x59, 0xEE, 0x85, 0x49, 0x11, 0xB6, 0x9C, 0x50, 0x61, 0x4A, 0xEC, 0xA3, 0x50, 0x96, 0xE3, 0x2F, 0x1A, 0x6D, 0x9B, 0x6B, 0x6E, 0xC4, 0x50, 0x50, 0x84, 0x29, 0x92, 0x93, 0xE0, 0x0F, 0xCB, 0xBB, 0x61, 0x5D, 0x36, 0x51, 0x1A, 0xBB, 0x73, 0x75, 0x83, 0xEF, 0xDB, 0x4B, 0x2A, 0x38, 0x2C, 0x37, 0x0A, 0x1F, 0x84, 0xE0, 0x9B, 0x24, 0xDF, 0x69, 0x0E, 0x5C, 0xD9, 0xAF, 0x89, 0x72, 0x45, 0x30, 0xA1, 0xDB, 0xA8, 0x22, 0x40, 0x42, 0x07, 0xCC, 0x2A, 0x0E, 0x90, 0x9A, 0x4D, 0xE5, 0x2B, 0x48, 0x86, 0x4D, 0x01, 0x25, 0x23, 0x95, 0xB5, 0xBD };
		Assert ("VerifySignature(SHA1, sign)", fmt.VerifySignature (hash, shaSignature));

		// bad signature
		shaSignature [0] = (byte) ~shaSignature [0];
		Assert ("VerifySignature(SHA1, badSign)", !fmt.VerifySignature (hash, shaSignature));

		// wrong signature length
		shaSignature = new byte [shaSignature.Length-1];
		Assert ("VerifySignature(SHA1, badSign)", !fmt.VerifySignature (hash, shaSignature));

		// good MD5
		fmt.SetHashAlgorithm ("MD5");
		hash = MD5.Create ();
		hash.ComputeHash (data);
		byte[] md5Signature = { 0x0F, 0xD6, 0x16, 0x2C, 0x31, 0xD6, 0xD7, 0xA0, 0xE8, 0xA0, 0x89, 0x53, 0x7B, 0x36, 0x8F, 0x25, 0xA5, 0xF6, 0x4A, 0x0B, 0xD3, 0xB9, 0x9B, 0xC4, 0xAE, 0xDC, 0xD4, 0x58, 0x5C, 0xD9, 0x58, 0x61, 0xE3, 0x66, 0x89, 0xB1, 0x1E, 0x33, 0x88, 0xDF, 0x58, 0xC4, 0x2E, 0xAE, 0xE7, 0x7B, 0x96, 0x61, 0x77, 0x91, 0xBD, 0xBD, 0x99, 0x9E, 0x1C, 0x3E, 0x0A, 0x5C, 0x15, 0x69, 0x00, 0xFA, 0xEE, 0xD7, 0xDC, 0xD2, 0x62, 0xA3, 0x31, 0x6A, 0x33, 0x75, 0xC8, 0x8E, 0x47, 0x5C, 0x1E, 0xD8, 0x91, 0x36, 0x65, 0xF3, 0x67, 0x63, 0xFC, 0x2B, 0x37, 0x7D, 0xE6, 0x2C, 0x2C, 0x09, 0x45, 0xE1, 0x8D, 0x8C, 0x8F, 0xFC, 0x6A, 0x4A, 0xD1, 0x4D, 0x06, 0xF3, 0x79, 0x9F, 0xDB, 0x0F, 0x4B, 0xD1, 0x94, 0x6F, 0xC7, 0xE7, 0x4E, 0x06, 0xDA, 0xDB, 0x2A, 0x51, 0x62, 0xCA, 0x1A, 0x31, 0x51, 0x2B, 0x83, 0xDD };
		Assert ("VerifySignature(MD5, sign)", fmt.VerifySignature (hash, md5Signature));

		// bad signature
		md5Signature [0] = (byte) ~md5Signature [0];
		Assert ("VerifySignature(MD5, badSign)", !fmt.VerifySignature (hash, md5Signature));

		// wrong signature length
		md5Signature = new byte [md5Signature.Length-1];
		Assert ("VerifySignature(MD5, badSign)", !fmt.VerifySignature (hash, md5Signature));
	}
}

}
