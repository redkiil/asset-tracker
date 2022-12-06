
using FleetApi.Data.FileSystem;
using Xunit;

public class MapLoaderTest
{
    [Fact]
    public void Should_Return_FileContent_String()
    {
        var mapLoader = new MapLoader();
        var expected = "{\"type\": \"FeatureCollection\", \"name\": \"MOCK_SETUP\", \"crs\": {\"type\": \"name\", \"properties\": {\"name\": \"urn:ogc:def:crs:OGC:1.3:CRS84\"}}, \"features\": [{\"type\": \"Feature\", \"properties\": {\"ID\": \"TEST\"}, \"geometry\": {\"type\": \"MultiPolygon\", \"coordinates\": [[[[-19, -52], [-19, -52], [-19, -52], [-19, -52]]]]}}]}";
        var current = mapLoader.LoadFile("");
        Assert.Equal(expected, current);        
    }
}