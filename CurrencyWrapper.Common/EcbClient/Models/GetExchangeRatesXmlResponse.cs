using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CurrencyWrapper.Common.EcbClient.Models
{
    [XmlRoot(ElementName = "GenericData", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
    public class GetExchangeRatesXmlResponse
    {

        [XmlElement(ElementName = "Header", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
        public Header Header { get; set; }

        [XmlElement(ElementName = "DataSet", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
        public DataSet DataSet { get; set; }

        [XmlAttribute(AttributeName = "message", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Message { get; set; }

        [XmlAttribute(AttributeName = "common", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Common { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "generic", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Generic { get; set; }

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Sender", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
    public class Sender
    {

        [XmlAttribute(AttributeName = "id", Namespace = "")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "Structure", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/common")]
    public class Structure
    {

        [XmlElement(ElementName = "URN", Namespace = "")]
        public string URN { get; set; }

        [XmlElement(ElementName = "Structure", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/common")]
        public Structure Structure1 { get; set; }

        [XmlAttribute(AttributeName = "structureID", Namespace = "")]
        public string StructureID { get; set; }

        [XmlAttribute(AttributeName = "dimensionAtObservation", Namespace = "")]
        public string DimensionAtObservation { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Header", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
    public class Header
    {

        [XmlElement(ElementName = "ID", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
        public string ID { get; set; }

        [XmlElement(ElementName = "Test", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
        public bool Test { get; set; }

        [XmlElement(ElementName = "Prepared", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
        public string Prepared { get; set; }

        [XmlElement(ElementName = "Sender", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
        public Sender Sender { get; set; }

        [XmlElement(ElementName = "Structure", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
        public Structure Structure { get; set; }
    }

    [XmlRoot(ElementName = "Value", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
    public class Val
    {

        [XmlAttribute(AttributeName = "id", Namespace = "")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "value", Namespace = "")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "SeriesKey", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
    public class SeriesKey
    {

        [XmlElement(ElementName = "Value", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
        public List<Val> Value { get; set; }
    }

    [XmlRoot(ElementName = "ObsDimension", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
    public class ObsDimension
    {

        [XmlAttribute(AttributeName = "value", Namespace = "")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "ObsValue", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
    public class ObsValue
    {

        [XmlAttribute(AttributeName = "value", Namespace = "")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Obs", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
    public class Obs
    {

        [XmlElement(ElementName = "ObsDimension", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
        public ObsDimension ObsDimension { get; set; }

        [XmlElement(ElementName = "ObsValue", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
        public ObsValue ObsValue { get; set; }
    }

    [XmlRoot(ElementName = "Series", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
    public class Series
    {

        [XmlElement(ElementName = "SeriesKey", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
        public SeriesKey SeriesKey { get; set; }

        [XmlElement(ElementName = "Obs", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
        public List<Obs> Obs { get; set; }
    }

    [XmlRoot(ElementName = "DataSet", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/message")]
    public class DataSet
    {

        [XmlElement(ElementName = "Series", Namespace = "http://www.sdmx.org/resources/sdmxml/schemas/v2_1/data/generic")]
        public List<Series> Series { get; set; }

        [XmlAttribute(AttributeName = "action", Namespace = "")]
        public string Action { get; set; }

        [XmlAttribute(AttributeName = "validFromDate", Namespace = "")]
        public string ValidFromDate { get; set; }

        [XmlAttribute(AttributeName = "structureRef", Namespace = "")]
        public string StructureRef { get; set; }
    }
}
