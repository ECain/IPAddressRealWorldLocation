/*
* Author: Edan Cain, ESRI, 380 New York Street, Redlands, California, 92373, USA. Email: ecain@esri.com Tel: 1-909-793-2853
*
* Code demonstrates how to structure REST calls to the Quoava test service to get the locations of IP addresses.
* User can query for their IP address for a singular test, or make a batch request. Batch requests as the code stands,
* requires the user to select a .csv file. File should be in the format of ID, IP per line. Each result is written to 
* another csv file. This file can be used to create a feature service from within the arcGIS.com for webclient.
*
* HttpWebResponses are dynamically binded too via the DataContract objects found within the QuovaDataContract.cs file.
*
* Code is not supported by ESRI inc, there are no use restrictions, you are free to distribute, modify and use this code.
* Enhancement or functional code requests should be sent to Edan Cain, ecain@esri.com.
*
* Code created to help support the Start-up community by the ESRI Emerging Business Team. If you are a start up company,
* please contact Myles Sutherland at msutherland@esri.com.
*/

using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace QuovaExample
{
  class Helper
  {
    public static Quova GetLocationResult(string fullURL)
    {
      JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

      // Create the web request
      HttpWebRequest request = WebRequest.Create(fullURL) as HttpWebRequest;

      // Get response
      string json;
      using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
      {
        json = DeserializeResponse(response.GetResponseStream());
      }

      Quova quovaResult = null;
      try
      {
        quovaResult = serializer.Deserialize<Quova>(json);
      }
      catch 
      {
        //do nothing
      }

      return quovaResult;
    }

    /// <summary>
    /// If you don't know what MD5 is please read:
    /// http://en.wikipedia.org/wiki/MD5
    /// </summary>
    /// <param name="strInput"></param>
    /// <returns></returns>
    public static string MD5GenerateHash(string strInput)
    {
      // Create a new instance of the MD5CryptoServiceProvider object. From System.Security.Cryptography
      MD5 md5Hasher = MD5.Create();

      // Convert the input string to a byte array and compute the hash.
      byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strInput));

      // Create a new Stringbuilder to collect the bytes and create a string.
      StringBuilder sBuilder = new StringBuilder();

      // Loop through each byte of the hashed data and format each one as a hexadecimal string.
      for (int nIndex = 0; nIndex < data.Length; ++nIndex)
      {
        sBuilder.Append(data[nIndex].ToString("x2"));
      }

      // Return the hexadecimal string.
      return sBuilder.ToString();
    }

    /// <summary>
    /// Deserialize the response stream into JSON
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    private static string DeserializeResponse(System.IO.Stream stream)
    {
      string JSON = string.Empty;

      using (StreamReader reader = new StreamReader(stream))
        JSON = reader.ReadToEnd();

      return JSON;
    }
  }
}
