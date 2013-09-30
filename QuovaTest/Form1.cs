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
using System.Net.Sockets;
using System.Windows.Forms;

namespace QuovaExample
{
  public partial class Form1 : Form
  {
    string _publicFacingIP;
    bool _once;
    bool _textWriteOnce;
    double _lat, _lon;
    StreamWriter _streamWriter;

    //Quoava Specific
    string _QuoavaService;
    string _version;
    string _method;
    string _apikey;
    string _secret;

    //Quoava test site allows for only 1000 requests per day
    //so exit the batch requests at this time.
    int _count = 0; 

    public Form1()
    {
      InitializeComponent();

      _QuoavaService = "http://api.quova.com/";
      _version = "v1/";
      _method = "ipinfo/";

      //Developers: please fill in these two required string values to make this work.
      //To get a trial account visit:
      //http://www.neustar.biz/enterprise/ip-intelligence
      //
      _apikey = "PLEASE SUPPLY YOUR API KEY";
      _secret = "PLEASE SUPPLY YOUR SECRET KEY";
    }

    #region Button Click Events
    private void btnRouterData_Click(object sender, EventArgs e)
    {
      GetRouterData();
    }

    private void btnGetIPAddress_Click(object sender, EventArgs e)
    {
      GetYourIPAddress();
    }

    private void btnQuovaLocationData_Click(object sender, EventArgs e)
    {
      ReturnLocationForSingleIPAddress();
    }
    #endregion

    #region Functions
    //Single IP request
    private void ReturnLocationForSingleIPAddress()
    {
      PopulateTextBox(QuovaRequest(_publicFacingIP));
      _once = false;
    }

    private void GetRouterData()
    {
      string server = Dns.GetHostName();
      txtRouterData.Text = "Using current host: " + server.ToString();

      // Get the list of the addresses associated with the requested server.
      IPAddresses(server);

      // Get additonal address information.
      IPAddressAdditionalInfo();
    }

    private Quova QuovaRequest(string ip)
    {
      //MD5: requirement of the Quova calls is the use of a encrypted digital signature and timestamp.
      string sig = Helper.MD5GenerateHash(_apikey + _secret + (Int32)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);

      string fullURL = _QuoavaService + _version + _method + ip + "?apikey=" + _apikey + "&sig=" + sig + "&format=json";
      Quova quova = Helper.GetLocationResult(fullURL);

      return quova;
    }

    private void PopulateTextBox(Quova quovaResult)
    {
      if (quovaResult == null)
        return;

      _lat = quovaResult.ipinfo.Location.latitude;
      _lon = quovaResult.ipinfo.Location.longitude;

      txtLocationData.Text = "IP Address: " + quovaResult.ipinfo.ip_address + "\r\n";
      txtLocationData.Text += "IP Type: " + quovaResult.ipinfo.ip_type + "\r\n";
      txtLocationData.Text += "\r\n";
      txtLocationData.Text += "Network" + "\r\n";
      txtLocationData.Text += "ASN: " + quovaResult.ipinfo.network.asn + "\r\n";
      txtLocationData.Text += "Carrier: " + quovaResult.ipinfo.network.carrier + "\r\n";
      txtLocationData.Text += "Connection Type: " + quovaResult.ipinfo.network.connection_type + "\r\n";
      txtLocationData.Text += "Domain: " + quovaResult.ipinfo.network.Domain.sld + "\r\n";
      txtLocationData.Text += "IP Routing Type: " + quovaResult.ipinfo.network.ip_routing_type + "\r\n";
      txtLocationData.Text += "Line Speed: " + quovaResult.ipinfo.network.line_speed + "\r\n";
      txtLocationData.Text += "Organization: " + quovaResult.ipinfo.network.organization + "\r\n";
      txtLocationData.Text += "\r\n";
      txtLocationData.Text += "Coordinates" + "\r\n";
      txtLocationData.Text += "Latitude: " + quovaResult.ipinfo.Location.latitude + "\r\n";
      txtLocationData.Text += "Longitude: " + quovaResult.ipinfo.Location.longitude + "\r\n";
      txtLocationData.Text += "\r\n";
      txtLocationData.Text += "Location" + "\r\n";
      txtLocationData.Text += "MSA" + quovaResult.ipinfo.Location.msa + "\r\n";
      txtLocationData.Text += "Area Code: " + quovaResult.ipinfo.Location.CityData.area_code + "\r\n";
      txtLocationData.Text += "City: " + quovaResult.ipinfo.Location.CityData.city + "\r\n";
      txtLocationData.Text += "City CF: " + quovaResult.ipinfo.Location.CityData.city_cf + "\r\n";
      txtLocationData.Text += "Postal Code: " + quovaResult.ipinfo.Location.CityData.postal_code + "\r\n";
      txtLocationData.Text += "Time Zone: " + quovaResult.ipinfo.Location.CityData.time_zone + "\r\n";
      txtLocationData.Text += "\r\n";
      txtLocationData.Text += "State Data" + "\r\n";
      txtLocationData.Text += "State: " + quovaResult.ipinfo.Location.StateData.state + "\r\n";
      txtLocationData.Text += "State CF: " + quovaResult.ipinfo.Location.StateData.state_cf + "\r\n";
      txtLocationData.Text += "State Code: " + quovaResult.ipinfo.Location.StateData.state_code + "\r\n";
      txtLocationData.Text += "\r\n";
      txtLocationData.Text += "Country Data" + "\r\n";
      txtLocationData.Text += "Country: " + quovaResult.ipinfo.Location.CountryData.country + "\r\n";
      txtLocationData.Text += "Country CF: " + quovaResult.ipinfo.Location.CountryData.country_cf + "\r\n";
      txtLocationData.Text += "Country Code: " + quovaResult.ipinfo.Location.CountryData.country_code + "\r\n";
      txtLocationData.Text += "\r\n";
      txtLocationData.Text += "Continent Data" + "\r\n";
      txtLocationData.Text += "Continent: " + quovaResult.ipinfo.Location.continent + "\r\n";

      //I hate to do it, but this is simply a one liner to create a map.
      Uri uri = new Uri("https://maps.google.com/maps?q=" + _lat + "," + _lon + "&hl=en&t=m&z=14");
      webBrowser1.Url = uri;
    }

    private void IPAddresses(string server)
    {
      try
      {
        System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

        // Get server related information.
        IPHostEntry heserver = Dns.GetHostEntry(server);

        // Loop on the AddressList
        foreach (IPAddress curAddress in heserver.AddressList)
        {
          // Display the type of address family supported by the server. If the
          // server is IPv6-enabled this value is: InternNetworkV6. If the server
          // is also IPv4-enabled there will be an additional value of InterNetwork.
          txtRouterData.Text += "\r\nAddressFamily: " + curAddress.AddressFamily.ToString();

          // Display the ScopeId property in case of IPV6 addresses.
          if (curAddress.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
            txtRouterData.Text += "\r\nScope Id: " + curAddress.ScopeId.ToString();

          // Display the server IP address in the standard format. In 
          // IPv4 the format will be dotted-quad notation, in IPv6 it will be
          // in in colon-hexadecimal notation.
          txtRouterData.Text += "\r\nAddress: " + curAddress.ToString();

          // Display the server IP address in byte format.
          txtRouterData.Text += "\r\nAddressBytes: ";

          Byte[] bytes = curAddress.GetAddressBytes();
          for (int i = 0; i < bytes.Length; i++)
          {
            txtRouterData.Text += bytes[i];
          }

          txtRouterData.Text += "\r\n";
        }
      }
      catch (Exception e)
      {
        txtRouterData.Text += "\r\n[DoResolve] Exception: " + e.ToString();
      }
    }

    // This IPAddressAdditionalInfo displays additional server address information.
    private void IPAddressAdditionalInfo()
    {
      try
      {
        // Display the flags that show if the server supports IPv4 or IPv6
        // address schemas.
        txtRouterData.Text += "\r\nSupportsIPv4: " + Socket.OSSupportsIPv4.ToString();
        txtRouterData.Text += "\r\nSupportsIPv6: " + Socket.OSSupportsIPv6.ToString();

        if (Socket.OSSupportsIPv6)//.SupportsIPv6)
        {
          // Display the server Any address. This IP address indicates that the server 
          // should listen for client activity on all network interfaces. 
          txtRouterData.Text += "\r\nIPv6Any: " + IPAddress.IPv6Any.ToString();

          // Display the server loopback address. 
          txtRouterData.Text += "\r\nIPv6Loopback: " + IPAddress.IPv6Loopback.ToString();

          // Used during autoconfiguration first phase.
          txtRouterData.Text += "\r\nIPv6None: " + IPAddress.IPv6None.ToString();

          txtRouterData.Text += "\r\nIsLoopback(IPv6Loopback): " + IPAddress.IsLoopback(IPAddress.IPv6Loopback);
        }
        txtRouterData.Text += "\r\nIsLoopback(Loopback): " + IPAddress.IsLoopback(IPAddress.Loopback);
      }
      catch (Exception e)
      {
        txtRouterData.Text += "\r\n[IPAddresses] Exception: " + e.ToString();
      }
    }

    /// <summary>
    /// Displays the IP address of this computer
    /// </summary>
    private void GetYourIPAddress()
    {
      HTTPGet req = new HTTPGet();
      req.Request("http://checkip.dyndns.org");
      string[] a = req.ResponseBody.Split(':');
      string a2 = a[1].Substring(1);
      string[] a3 = a2.Split('<');

      //store the ip address for use with Quoava to get your location.
      _publicFacingIP = a3[0];
      lblIP.Text = _publicFacingIP;
      btnQuovaLocationData.Enabled = true;
    }

    private void btnQuovaBatchData_Click(object sender, EventArgs e)
    {
      BatchRequestIPAddresses();
    }

    /// <summary>
    /// Allow the user to open a csv file containing IP data. 
    /// Alter in the code the splitting of each record string within the csv file,
    /// all we want is the IP initially. My data contains an identifying name, and 
    /// the IP address. The identifying name (ID) is used when creating a resultant csv file.
    /// This file contains:
    /// ID, ip_address, latitude, longitude, city, state, country, continent
    /// </summary>
    private void BatchRequestIPAddresses()
    {
      Stream myStream = null;
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      //Allow user to pick csv file containing the IP addresses
      openFileDialog1.InitialDirectory = "c:\\";
      openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
      openFileDialog1.FilterIndex = 0;
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        try
        {
          if ((myStream = openFileDialog1.OpenFile()) != null)
          {
            //on successful opening read data.
            using (myStream)
            {
              string data = string.Empty;

              using (StreamReader reader = new StreamReader(myStream))
                data = reader.ReadToEnd();

              myStream.Close();

              //split the data on the carriage return
              string[] data2 = data.Split('\r');
              string[] splitRecord; //variable to contain the ID and IP
              Quova quova;

              for (int i = 1; i < data2.Length; i++)
              {
                //NB: Quova dev license limits 1000 requests per day
                if (i == 1000)
                {
                  break;
                }

                //from the current record split it based on a comma to get the ID and IP
                splitRecord = data2[i].Split(',');
                
                //do we have rubbish
                if (splitRecord == null)
                  continue;

                //in my data's case the second element contains the IP
                quova = QuovaRequest(splitRecord[1]);

                //if successful lets write the locational ID, IP and locational data to our own csv file.
                if(quova != null)
                  WriteToCSVFile(splitRecord[0], quova);
              }
              _streamWriter.Close();
            }
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        }
      }
    }

    /// <summary>
    /// Single result of a batch Quova request for location data is appended to the 
    /// csv file listed in code. Change this as needed. 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="quova"></param>
    private void WriteToCSVFile(string id, Quova quova)
    {
      _count++;
      if (_count == 16)
        _count = 16;

      if (!_textWriteOnce)
      {
        FileInfo t = new FileInfo("C:\\Temp\\Results2.csv");
        _streamWriter = t.CreateText();
        _streamWriter.WriteLine("ID,IP,Lat,Lon,City,State,Country,Continent");
        _streamWriter.AutoFlush = true;
        _textWriteOnce = true;
      }
      else
      {
        //NB: Quova limits 2 requests per second
        System.Threading.Thread.Sleep(500);

        _streamWriter.WriteLine(id + ", " + quova.ipinfo.ip_address + ", " + quova.ipinfo.Location.latitude + ", " + quova.ipinfo.Location.longitude + ", " + quova.ipinfo.Location.CityData.city + ", " + quova.ipinfo.Location.StateData.state + ", " + quova.ipinfo.Location.CountryData.country + ", " + quova.ipinfo.Location.continent);
      }
    }
    #endregion
  }
}
