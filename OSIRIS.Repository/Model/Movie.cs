using System;
using System.Collections.Generic;
using System.Text;

namespace OSIRIS.Repository.Model
{
    public class Torrent
    {
        public string Url { get; set; }
        public string Hash { get; set; }
        public string Quality { get; set; }
        public string Type { get; set; }
        public int Seeds { get; set; }
        public int Peers { get; set; }
        public string Size { get; set; }
        public int SizeBytes { get; set; }
        public string DateUploaded { get; set; }
        public int DateUploadedUnix { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ImdbCode { get; set; }
        public string Title { get; set; }
        public string TitleEnglish { get; set; }
        public string TitleLong { get; set; }
        public string Slug { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public int Runtime { get; set; }
        public IList<string> Genres { get; set; }
        public string Summary { get; set; }
        public string DescriptionFull { get; set; }
        public string Synopsis { get; set; }
        public string YtTrailerCode { get; set; }
        public string Language { get; set; }
        public string MpaRating { get; set; }
        public string BackgroundImage { get; set; }
        public string BackgroundImageOriginal { get; set; }
        public string SmallCoverImage { get; set; }
        public string MediumCoverImage { get; set; }
        public string LargeCoverImage { get; set; }
        public string State { get; set; }
        public IList<Torrent> Torrents { get; set; }
        public string DateUploaded { get; set; }
        public int DateUploadedUnix { get; set; }
    }

    public class Data
    {
        public int MovieCount { get; set; }
        public int Limit { get; set; }
        public int PageNumber { get; set; }
        public IList<Movie> Movies { get; set; }
    }



    public class MovieResponse1
    {
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public Data Data { get; set; }
    }


    public class SingleMovie
    {
        public Movie Movie { get; set; }
    }
    public class SingleMovieResponse1
    {
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public SingleMovie Data { get; set; }
    }
}
