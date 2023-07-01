using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData {
    public static void Initialize(IServiceProvider serviceProvider) {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>())) {
            // Look for any movies.
            if (context.Movie.Any()) {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie {
                    Title = "How Rare a Possession",
                    ReleaseDate = DateTime.Parse("1987-11-8"),
                    Genre = "Documentary",
                    Rating = "Not Rated",
                    Price = 7.99M,
                    Image = "how-rare-a-possession.jpg"
                },
                new Movie {
                    Title = "Joseph Smith: The Prophet of the Restoration",
                    ReleaseDate = DateTime.Parse("2005-12-17"),
                    Genre = "Documentary",
                    Rating = "Not Rated",
                    Price = 8.99M,
                    Image = "joseph-smith-prophet-of-the-restoration.jpg"
                },
                new Movie {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Rating = "PG",
                    Price = 9.99M,
                    Image = "meet-the-mormons.jpg"
                },
                new Movie {
                    Title = "The Other Side of Heaven 2",
                    ReleaseDate = DateTime.Parse("2019-6-28"),
                    Genre = "Drama",
                    Rating = "PG-13",
                    Price = 12.99M,
                    Image = "the-other-side-of-heaven-2.jpg"
                },
                new Movie {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-10-14"),
                    Genre = "Drama",
                    Rating = "PG",
                    Price = 7.99M,
                    Image = "the-other-side-of-heaven.jpg"
                }
            );
            context.SaveChanges();
        }
    }
}