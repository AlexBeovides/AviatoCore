using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Application.Services;
using AviatoCore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // GET: api/Facilities 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviews([FromQuery] int airportId)
    {
        var reviews = await _reviewService.GetReviewsByAirportIdAsync(airportId);
        return Ok(reviews);
    }

    // GET: api/Facilities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id, [FromQuery] int airportId)
    {
        var review = await _reviewService.GetReviewAsync(id, airportId);

        if (review == null)
        {
            return NotFound();
        }

        return review;
    }
    // POST: api/Reviews
    [Authorize(Roles = "Client")]
    [HttpPost]
    public async Task<ActionResult<Review>> PostReview(ReviewDto reviewDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var review = new Review
        {
            Id = reviewDto.Id,
            Rating = reviewDto.Rating,
            Comment = reviewDto.Comment,
            ReviewedAt = DateTime.UtcNow,
            ClientId = userId,
            ServiceId = reviewDto.ServiceId
        };

        await _reviewService.AddReviewAsync(review);

        reviewDto.Id = review.Id; // Assuming AddServiceAsync sets the Id of the service

        return CreatedAtAction("GetReview", new { id = review.Id }, review);
    }
}