using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SILClient.Models.Class;

namespace SILClient.Models.Data;

public class DataUtil : IDisposable
{
	private static readonly Logger log = LogManager.GetCurrentClassLogger();

	public string GetWSCuposCorretajeCliente()
	{
		return ConfigurationManager.AppSettings["RSRC_SERVER"];
	}

	public async Task<string> RequestAsync(string Action)
	{
		string token = GetTokenAsync();
		HttpClient client = new HttpClient();
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		return JArray.Parse(await client.GetStringAsync(GetWSCuposCorretajeCliente() + Action)).ToString();
	}

	public async Task<T> RequestGetAndDeserializeAsync<T>(string Action)
	{
		string token = GetTokenAsync();
		HttpClient client = new HttpClient();
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		return await DeserializeAsync<T>(await client.GetStringAsync(GetWSCuposCorretajeCliente() + "/" + Action));
	}

	public async Task<T> RequestPostAndDeserializeAsync<T>(string Action, object Data)
	{
		string token = GetTokenAsync();
		HttpClient client = new HttpClient();
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		string jsonString = JsonConvert.SerializeObject(Data);
		HttpResponseMessage json = await client.PostAsync(content: new StringContent(jsonString, Encoding.UTF8, "application/json"), requestUri: GetWSCuposCorretajeCliente() + "/" + Action);
		if (json.StatusCode == HttpStatusCode.NotFound)
		{
			throw new Exception("No se encontro el action en el resource server.");
		}
		return await DeserializeAsync<T>(await json.Content.ReadAsStringAsync());
	}

	public async Task<T> DeserializeAsync<T>(string JsonResponse)
	{
		log.Debug(JsonResponse);
		return await Task.FromResult(JsonConvert.DeserializeObject<T>(JsonResponse));
	}

	public T Deserialize<T>(string JsonResponse)
	{
		return JsonConvert.DeserializeObject<T>(JsonResponse);
	}

	private string GetTokenAsync()
	{
		return ClaimsUtil.GetAccessToken();
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
