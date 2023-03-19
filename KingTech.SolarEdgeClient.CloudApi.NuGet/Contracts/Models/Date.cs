using System.Globalization;

namespace KingTech.SolarEdgeClient.CloudApi.Contracts.Models;

public class Date
{
    public string DateString
    {
        get => _innerDate.ToString(Format, CultureInfo.InvariantCulture);
        set => _innerDate = DateTime.ParseExact(value, Format, CultureInfo.InvariantCulture);
    }

    private const string Format = "yyyy-MM-dd";
    private DateTime _innerDate;

    public Date()
    {
        _innerDate = DateTime.MinValue;
    }

    public Date(DateTime date)
    {
        _innerDate = date;
    }

    public Date(string dateString)
    {
        DateString = dateString;
    }

    public override string ToString() => DateString;
}