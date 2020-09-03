using HtmlAgilityPack;
using KonusarakOgren.Quiz.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KonusarakOgren.Quiz.MvcWebUI.Helpers
{
    public class HtmlScrap
    {
        
        public static async Task<List<PostModel>> GetHtmlAsync()
        {
            var url = "https://www.wired.com/";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var PostHtml = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("post-listing-component__list")).ToList();
            var PostListItems = PostHtml[1].Descendants("li")
                .Where(node=>node.GetAttributeValue("class","")
                .Equals("post-listing-list-item__post")).ToList();
            List<PostModel> PostList = new List<PostModel>();
            PostModel post = null;
            foreach (var PostListItem in PostListItems)
            {
                
                post = new PostModel
                {
                    Title = PostListItem.Descendants("h5")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("post-listing-list-item__title")).FirstOrDefault().InnerText,
                    Author= PostListItem.Descendants("span")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("byline-component__content")).FirstOrDefault().InnerText,
                    Url= url+ PostListItem.Descendants("a").FirstOrDefault().GetAttributeValue("href","")
                };
                var PostDescription = await GetDescription(post.Url);
                post.Description = PostDescription;

                PostList.Add(post);
                
            }
            return PostList;
        }
        
        public static async Task<string> GetDescription(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var DescriptionHtmlList = htmlDocument.DocumentNode.Descendants("article")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("article-body-component article-body-component--null")).ToList();
            var PostDescription=DescriptionHtmlList[0].Descendants("p").FirstOrDefault().InnerText;
            return PostDescription;
        }
    }
 
}
