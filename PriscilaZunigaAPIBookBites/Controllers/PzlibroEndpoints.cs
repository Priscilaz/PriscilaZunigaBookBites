using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using PriscilaZunigaAPIBookBites.Data;
using PriscilaZunigaAPIBookBites.Data.Models;
namespace PriscilaZunigaAPIBookBites.Controllers;

public static class PzlibroEndpoints
{
    public static void MapPzlibroEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Pzlibro").WithTags(nameof(Pzlibro));

        group.MapGet("/", async (Context db) =>
        {
            return await db.Pzlibro.ToListAsync();
        })
        .WithName("GetAllPzlibros")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Pzlibro>, NotFound>> (int pzlibroid, Context db) =>
        {
            return await db.Pzlibro.AsNoTracking()
                .FirstOrDefaultAsync(model => model.PzlibroId == pzlibroid)
                is Pzlibro model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPzlibroById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int pzlibroid, Pzlibro pzlibro, Context db) =>
        {
            var affected = await db.Pzlibro
                .Where(model => model.PzlibroId == pzlibroid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.PzlibroId, pzlibro.PzlibroId)
                    .SetProperty(m => m.Pztitulo, pzlibro.Pztitulo)
                    .SetProperty(m => m.Pzautor, pzlibro.Pzautor)
                    .SetProperty(m => m.Pzvolumen, pzlibro.Pzvolumen)
                    .SetProperty(m => m.Pzprecio, pzlibro.Pzprecio)
                    .SetProperty(m => m.Pznombre, pzlibro.Pznombre)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePzlibro")
        .WithOpenApi();

        group.MapPost("/", async (Pzlibro pzlibro, Context db) =>
        {
            db.Pzlibro.Add(pzlibro);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Pzlibro/{pzlibro.PzlibroId}",pzlibro);
        })
        .WithName("CreatePzlibro")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int pzlibroid, Context db) =>
        {
            var affected = await db.Pzlibro
                .Where(model => model.PzlibroId == pzlibroid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePzlibro")
        .WithOpenApi();
    }
}
