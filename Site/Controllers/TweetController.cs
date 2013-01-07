using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using External;
using Site.Models;
using Entities;

namespace Site.Controllers
{
    public class TweetController : BootstrapBaseController
    {
        private readonly WW13DbContext dbContext;
        public TweetController()
        {
            this.dbContext = new WW13DbContext();
        }

        public ActionResult Index()
        {
            var model = new List<TweetModel>();

            foreach (var tweet in dbContext.Tweets)
            {
                model.Add(GetTweetModel(tweet));
            }
            
            return View(model);
        }

        private TweetModel GetTweetModel(Entities.Tweet tweet)
        {
            return new TweetModel()
            {
                Id = tweet.Id,
                Message = tweet.Message,
                User = tweet.User
            };
        }

        public ActionResult Details(int id)
        {
            return View(GetTweetModel(id));
        }


        public ActionResult Create()
        {
            return View(new TweetModel());
        }


        [HttpPost]
        public ActionResult Create(TweetModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tweet = new Entities.Tweet()
                    {
                        Message = model.Message,
                        User = model.User
                    };

                    dbContext.Tweets.Add(tweet);
                    dbContext.SaveChanges();

                    Success("Tweet aangemaakt");

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(GetTweetModel(id));
        }


        [HttpPost]
        public ActionResult Edit(TweetModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tweet = GetTweet(model.Id);
                    tweet.User = model.User;
                    tweet.Message = model.Message;
                    dbContext.SaveChanges();

                    Success("Tweet bewerkt");

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        private TweetModel GetTweetModel(int tweetId)
        {
            var tweet = GetTweet(tweetId);
            var model = GetTweetModel(tweet);
            return model;
        }

        private Entities.Tweet GetTweet(int tweetId)
        {
            var tweet = dbContext.Tweets.Find(tweetId);
            return tweet;
        }

        //
        // GET: /Tweet/Delete/5

        public ActionResult Delete(int id)
        {
            return View(GetTweetModel(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
