using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DemoBlog.Models
{
    [DataContract(Name="entry")]
    public class Entry
    {
        public Entry()
        {
            Tags = new List<string>();
            Comments=new List<Comment>();
        }

        public string Id { get; set; }
        
        [DataMember(Name="slug")]
        public string Slug { get; set; }
        
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "creationDate")]
        public DateTime CreationDate { get; set; }

        [DataMember(Name = "publishDate")]
        public DateTime? PublishDate { get; set; }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        [DataMember(Name = "comments")]
        public List<Comment> Comments { get; set; }
    }


    [DataContract(Name = "comment")]
    public class Comment
    {

        [DataMember(Name = "user")]
        public string User { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}