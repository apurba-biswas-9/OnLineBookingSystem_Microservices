using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.DataModel;

namespace Books
{
    public class DAL
    {
        private IList<Book> _books { get; set; }
        public DAL()
        {
            _books = new List<Book>();

            //Arts_Music
            _books.Add(new Book
            {
                Id = 1,
                BookCategories = BookCategories.Arts_Music,
                BooksTitle = "A Lesson Before Dying (Oprah's Book Club)",
                Price  = 100
            });

            _books.Add(new Book
            {
                Id = 2,
                BookCategories = BookCategories.Arts_Music,
                BooksTitle = "The Fellowship of the Ring",
                Price = 200
            });

            //Biographies
            _books.Add(new Book
            {
                Id = 3,
                BookCategories = BookCategories.Biographies,
                BooksTitle = "Bharat Vibhajan (Hindi)",
                Price = 389
            });

            _books.Add(new Book
            {
                Id = 4,
                BookCategories = BookCategories.Biographies,
                BooksTitle = "Adolf Hitler",
                Price = 270
            });

            //Business
            _books.Add(new Book
            {
                Id = 5,
                BookCategories = BookCategories.Business,
                BooksTitle = "The Richest Man in Babylon",
                Price = 99
            });


            _books.Add(new Book
            {
                Id = 6,
                BookCategories = BookCategories.Business,
                BooksTitle = "TThink & Grow Rich",
                Price = 70
            });

            //Comics
            _books.Add(new Book
            {
                Id = 7,
                BookCategories = BookCategories.Comics,
                BooksTitle = "Castafiore Emerald (Tintin)",
                Price = 349
            });


            _books.Add(new Book
            {
                Id = 8,
                BookCategories = BookCategories.Comics,
                BooksTitle = "Marvel Avengers Alliance (2016)",
                Price = 450
            });


            //Computers_Tech
            _books.Add(new Book
            {
                Id = 9,
                BookCategories = BookCategories.Computers_Tech,
                BooksTitle = "MOBJECTIVE Computer Awareness",
                Price = 133
            });

            _books.Add(new Book
            {
                Id = 10,
                BookCategories = BookCategories.Computers_Tech,
                BooksTitle = "Computer Aptitude & Awareness (Competition Series)",
                Price = 185
            });

            //Cooking

            _books.Add(new Book
            {
                Id = 11,
                BookCategories = BookCategories.Cooking,
                BooksTitle = "Royal Hyderabadi Cooking",
                Price = 350
            });

            _books.Add(new Book
            {
                Id = 12,
                BookCategories = BookCategories.Cooking,
                BooksTitle = "The Lucknow Cookbook",
                Price = 279
            });

            //Entertainment
            _books.Add(new Book
            {
                Id = 13,
                BookCategories = BookCategories.Entertainment,
                BooksTitle = "Coraline: An Adventure Too Weird for Words",
                Price = 279
            });

            _books.Add(new Book
            {
                Id = 14,
                BookCategories = BookCategories.Entertainment,
                BooksTitle = "Coraline: An Adventure Too Weird for Words",
                Price = 279
            });

            //History
            _books.Add(new Book
            {
                Id = 15,
                BookCategories = BookCategories.History,
                BooksTitle = "Ancient and Medieval India",
                Price = 350
            });

            _books.Add(new Book
            {
                Id = 16,
                BookCategories = BookCategories.History,
                BooksTitle = "History of Modern India",
                Price = 240
            });

            //Hobbies

            _books.Add(new Book
            {
                Id = 17,
                BookCategories = BookCategories.Hobbies,
                BooksTitle = "Disney Frozen Hairstyles: Inspired by Anna and Elsa",
                Price = 733
            });

            _books.Add(new Book
            {
                Id = 18,
                BookCategories = BookCategories.Hobbies,
                BooksTitle = "Colour with Crayons - Part 1",
                Price = 48
            });

            //Horror

            _books.Add(new Book
            {
                Id = 19,
                BookCategories = BookCategories.Horror,
                BooksTitle = "The Green Room",
                Price = 189
            });

            _books.Add(new Book
            {
                Id = 20,
                BookCategories = BookCategories.Horror,
                BooksTitle = "Dracula",
                Price = 139
            });

            //Kids
            _books.Add(new Book
            {
                Id = 21,
                BookCategories = BookCategories.Kids,
                BooksTitle = "Peppa Pig: Little Library",
                Price = 145
            });

            _books.Add(new Book
            {
                Id = 22,
                BookCategories = BookCategories.Kids,
                BooksTitle = "Great Stories for Children",
                Price = 95
            });

            //Litrature
            _books.Add(new Book
            {
                Id = 23,
                BookCategories = BookCategories.Litrature,
                BooksTitle = "Devdas",
                Price = 95
            });

            _books.Add(new Book
            {
                Id = 24,
                BookCategories = BookCategories.Litrature,
                BooksTitle = "Charitrheen",
                Price = 120
            });

            //Medical
            _books.Add(new Book
            {
                Id = 25,
                BookCategories = BookCategories.Medical,
                BooksTitle = "Clinical Neuroanatomy with the Point Access Scratch Code",
                Price = 955
            });

            _books.Add(new Book
            {
                Id = 26,
                BookCategories = BookCategories.Medical,
                BooksTitle = "Essentials of Medical Pharmacology",
                Price = 1200
            });

            //Sports
            _books.Add(new Book
            {
                Id = 27,
                BookCategories = BookCategories.Sports,
                BooksTitle = "Athletics 2019",
                Price = 95
            });

            _books.Add(new Book
            {
                Id = 28,
                BookCategories = BookCategories.Sports,
                BooksTitle = "The Art of Bradman",
                Price = 120
            });

            //Sports
            _books.Add(new Book
            {
                Id = 29,
                BookCategories = BookCategories.Travel,
                BooksTitle = "2500 Kms Lost on Road",
                Price = 290
            });

            _books.Add(new Book
            {
                Id = 30,
                BookCategories = BookCategories.Travel,
                BooksTitle = "India The Journey - A Travel Book on India",
                Price = 500
            });


        }
        public IList<Book> GetBooks() => _books;
    }
}
