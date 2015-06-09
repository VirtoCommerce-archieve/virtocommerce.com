using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Publishing.Model;

namespace VirtoCommerce.Helpers.Models
{
    public class ContentItem
    {
        public ContentItem()
        {
            Categories = Enumerable.Empty<string>();
        }

        public void SetHeaderSettings(IDictionary<string, object> settings)
        {
            foreach (var setting in settings)
            {
                switch (setting.Key.ToLower())
                {
                    case "categories":
                    case "category":
                        {
                            var categories = ((string)setting.Value).Split(
                                new[] { "," },
                                StringSplitOptions.RemoveEmptyEntries);

                            Categories = categories.Select(x => x.Trim()).OrderBy(x => x);

                            break;
                        }
                    case "title":
                        {
                            Title = (string)setting.Value;
                            break;
                        }
					case "canonical":
						{
							Canonical = (string)setting.Value;
							break;
						}
                    case "layout":
                        {
                            Layout = (string)setting.Value;
                            break;
                        }
                    case "author":
                        {
                            Author = (string)setting.Value;
                            break;
                        }
                    case "email":
                        {
                            Email = (string)setting.Value;
                            break;
                        }
                    case "published":
                        {
                            Published published;
                            Enum.TryParse((string)setting.Value, true, out published);
                            Published = published;
                            break;
                        }
                    case "series":
                        {
                            //Series = (Series)setting.Value;
                            break;
                        }
                    case "metadescription":
                        {
                            MetaDescription = (string)setting.Value;
                            break;
                        }
					case "ogimage":
						{
							OgImage = (string)setting.Value;
							break;
						}
					case "ogtitle":
						{
							OgTitle = (string)setting.Value;
							break;
						}
					case "ogsitename":
						{
							OgSitename = (string)setting.Value;
							break;
						}
					case "twittercard":
						{
							TwitterCard = (string)setting.Value;
							break;
						}
					case "twittertitle":
						{
							TwitterTitle = (string)setting.Value;
							break;
						}
					case "twitterdescription":
						{
							TwitterDescription = (string)setting.Value;
							break;
						}
					case "twitterimage":
						{
							TwitterImage = (string)setting.Value;
							break;
						}
					case "twittersite":
						{
							TwitterSite = (string)setting.Value;
							break;
						}
                    case "tags":
                    case "keywords":
                        {
                            //Keywords = (string)setting.Value;

                            break;
                        }
                }
            }
        }

        public string MetaDescription { get; set; }

        //public Series Series { get; set; }


        private string excerpt;
        public string ContentExcerpt
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(excerpt))
                {
                    return excerpt;
                }

                return Content.Split(new[] { "<!--excerpt-->" }, StringSplitOptions.None)[0];
            }
            set { excerpt = value; }
        }

        public string Author { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> Categories { get; set; }
        public string Keywords { get; set; }

        //public Published Published { get; set; }
        public string Title { get; set; }
		public string Canonical { get; set; }
        public string Content { get; set; }
        public string Layout { get; set; }
        public IDictionary<string, dynamic> Settings { get; set; }
        public string FileName { get; set; }

		public string OgImage { get; set; }
		public string OgTitle { get; set; }
		public string OgSitename { get; set; }

		public string TwitterCard { get; set; }
		public string TwitterTitle { get; set; }
		public string TwitterDescription { get; set; }
		public string TwitterImage { get; set; }
		public string TwitterSite { get; set; }

        public Published Published { get; set; }

        public string Url { get; set; }

        public DateTime Date { get; set; }
    }
}