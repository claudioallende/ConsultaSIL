using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace SsoOIDC_ACA.Configuracion;

internal static class Certificate
{
	public static X509Certificate2 Get()
	{
		Assembly assembly = typeof(Certificate).Assembly;
		using Stream input = assembly.GetManifestResourceStream("SILClient.Configuracion.idsrv3test.pfx");
		return new X509Certificate2(ReadStream(input), "idsrv3test");
	}

	private static byte[] ReadStream(Stream input)
	{
		byte[] array = new byte[16384];
		using MemoryStream memoryStream = new MemoryStream();
		int count;
		while ((count = input.Read(array, 0, array.Length)) > 0)
		{
			memoryStream.Write(array, 0, count);
		}
		return memoryStream.ToArray();
	}
}
