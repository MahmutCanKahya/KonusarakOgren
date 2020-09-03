using HtmlAgilityPack;
using KonusarakOgren.Quiz.Entities.Concrete;
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
        
        public static async Task<List<Exam>> GetHtmlAsync()
        {
            var url = "https://www.wired.com";

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
            List<Exam> PostList = new List<Exam>();
            Exam exam = null;
            //var i = 0;
            foreach (var PostListItem in PostListItems)
            {
                exam = new Exam();
                /*i++;
                post = new Exam
                {
                    Id = i,
                    Title = PostListItem.Descendants("h5")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("post-listing-list-item__title")).FirstOrDefault().InnerText,
                    Author= PostListItem.Descendants("span")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("byline-component__content")).FirstOrDefault().InnerText,
                    Url= url+ PostListItem.Descendants("a").FirstOrDefault().GetAttributeValue("href","")
                };*/
                var PostUrl = url + PostListItem.Descendants("a").FirstOrDefault().GetAttributeValue("href", "");
                var PostDescription = await GetDescription(PostUrl);
                exam.ExamText = PostDescription;
                exam.ExamTitle = PostListItem.Descendants("h5")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("post-listing-list-item__title")).FirstOrDefault().InnerText;

                PostList.Add(exam);
                
            }
            return PostList;
        }
        
        public static async Task<string> GetDescription(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var DescriptionHtmlList = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("grid--item body body__container article__body grid-layout__content")).ToList();
            var PostDescription=DescriptionHtmlList[0].Descendants("p").FirstOrDefault().InnerText;
            return PostDescription;
        }
    }
 
}
