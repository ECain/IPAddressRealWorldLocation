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

using System.Runtime.Serialization;

namespace QuovaExample
{
  [DataContract]
  class Quova
  {
    [DataMember]
    public ipinfo ipinfo { get; set;}
  }

  [DataContract]
  class ipinfo
  {
    [DataMember]
    public string ip_address { get; set; }

    [DataMember]
    public string ip_type { get; set; }

    [DataMember]
    public object anonymizer_status { get; set; }

    [DataMember]
    public Network network { get; set; }

    [DataMember]
    public Location Location { get; set; }
  }

  [DataContract]
  class Location
  {
    [DataMember]
    public string continent { get; set; }

    [DataMember]
    public double latitude { get; set; }

    [DataMember]
    public double longitude { get; set; }

    [DataMember]
    public CountryData CountryData { get; set; }

    [DataMember]
    public object region { get; set; }

    [DataMember]
    public StateData StateData { get; set; }

    [DataMember]
    public object dma { get; set; }

    [DataMember]
    public object msa { get; set; }

    [DataMember]
    public CityData CityData { get; set; }
  }

  [DataContract]
  class CountryData
  {
    [DataMember]
    public string country { get; set; }

    [DataMember]
    public string country_code { get; set; }

    [DataMember]
    public object country_cf { get; set; }
  }

  [DataContract]
  class StateData
  {
    [DataMember]
    public object state { get; set; }

    [DataMember]
    public object state_code { get; set; }

    [DataMember]
    public object state_cf { get; set; }
  }

  [DataContract]
  class CityData
  {
    [DataMember]
    public object city { get; set; }

    [DataMember]
    public object postal_code { get; set; }

    [DataMember]
    public object time_zone { get; set; }

    [DataMember]
    public object area_code { get; set; }

    [DataMember]
    public object city_cf { get; set; }
  }

  [DataContract]
  class Network
  {
    [DataMember]
    public string organization { get; set; }

    [DataMember]
    public OrganizationData organizationData { get; set; }

    [DataMember]
    public object carrier { get; set; }

    [DataMember]
    public object asn { get; set; }

    [DataMember]
    public string connection_type { get; set; }

    [DataMember]
    public string line_speed { get; set; }

    [DataMember]
    public string ip_routing_type { get; set; }

    [DataMember]
    public Domain Domain { get; set; }
  }

  [DataContract]
  class Domain
  {
    [DataMember]
    public object tld { get; set; }

    [DataMember]
    public object sld { get; set; }
  }

  [DataContract]
  class OrganizationData
  {
    [DataMember]
    public bool home { get; set; }

    [DataMember]
    public string organization_type { get; set; }

    [DataMember]
    public string naics_code { get; set; }

    [DataMember]
    public string isic_code { get; set; }
  }
}

