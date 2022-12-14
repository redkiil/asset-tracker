
using System.Text;
using FleetApi.Data.FileSystem;
using Xunit;

public class MapLoaderTest
{
    [Fact]
    public void Should_Return_FileContent_String()
    {
        string filePath = $"{System.IO.Path.GetTempPath()}/test.geojson";
        try{
            using(FileStream fs = File.Create(filePath))
            {
                var fileContent = "{\"type\": \"FeatureCollection\", \"name\": \"MOCK_SETUP\", \"crs\": {\"type\": \"name\", \"properties\": {\"name\": \"urn:ogc:def:crs:OGC:1.3:CRS84\"}}, \"features\": [{\"type\": \"Feature\", \"properties\": {\"SETOR_TP\": \"TEST\"}, \"geometry\": {\"type\": \"MultiPolygon\", \"coordinates\": [[[[-19, -52], [-19, -52], [-19, -52], [-19, -52]]]]}}]}";
                byte[] data = new UTF8Encoding(true).GetBytes(fileContent);
                fs.Write(data, 0, data.Length);
            }
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }
        var mapLoader = new MapLoader(filePath);
        var listFields = mapLoader.LoadGeoJson();
        Assert.Single(listFields);
        Assert.Equal("TEST", listFields[0].properties.setor);
    }
}