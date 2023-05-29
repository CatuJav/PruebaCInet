namespace APLICACION.Models;


using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class EnTendencia
{
    [JsonProperty("page")]
    public long Page { get; set; }

    [JsonProperty("results")]
    public List<Result> Results { get; set; }

    [JsonProperty("total_pages")]
    public long TotalPages { get; set; }

    [JsonProperty("total_results")]
    public long TotalResults { get; set; }
}

public partial class Result
{
    [JsonProperty("adult")]
    public bool Adult { get; set; }

    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title", NullValueHandling = NullValueHandling.Ignore)]
    public string OriginalTitle { get; set; }

    [JsonProperty("overview")]
    public string Overview { get; set; }

    [JsonProperty("poster_path")]
    public string PosterPath { get; set; }

    [JsonProperty("media_type")]
    public MediaType MediaType { get; set; }

    [JsonProperty("genre_ids")]
    public List<long> GenreIds { get; set; }

    [JsonProperty("popularity")]
    public double Popularity { get; set; }

    [JsonProperty("release_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? ReleaseDate { get; set; }

    [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Video { get; set; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }

    [JsonProperty("vote_count")]
    public long VoteCount { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("original_name", NullValueHandling = NullValueHandling.Ignore)]
    public string OriginalName { get; set; }

    [JsonProperty("first_air_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? FirstAirDate { get; set; }

    [JsonProperty("origin_country", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> OriginCountry { get; set; }
}

public enum MediaType { Movie, Tv };

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                MediaTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}

internal class MediaTypeConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(MediaType) || t == typeof(MediaType?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "movie":
                return MediaType.Movie;
            case "tv":
                return MediaType.Tv;
        }
        throw new Exception("Cannot unmarshal type MediaType");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (MediaType)untypedValue;
        switch (value)
        {
            case MediaType.Movie:
                serializer.Serialize(writer, "movie");
                return;
            case MediaType.Tv:
                serializer.Serialize(writer, "tv");
                return;
        }
        throw new Exception("Cannot marshal type MediaType");
    }

    public static readonly MediaTypeConverter Singleton = new MediaTypeConverter();
}