using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WePostIt.API.Abstract;
using WePostIt.API.Domain;
using WePostIt.API.DTOs;

namespace WePostIt.API.Controllers
{
    [Route("[controller]")]
    public class AuthorController(
            ILogger<AuthorController> logger,
            IAuthorRepository repository) 
        : ControllerBase
    {
        private readonly ILogger<AuthorController> logger = logger;
        private readonly IAuthorRepository repository = repository;

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await repository.GetAll());
            }
            catch(Exception exc)
            {
                logger.LogTrace(exc, "Error while getting authors");
                /* Microsoft.AspNetCore.Http ci fornisce un'alternativa 
                 * all'enum System.Net.HttpStatusCode: la classe statica
                 * Microsoft.AspNetCore.Http.StatusCodes
                 */
                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Error while getting authors",
                    detail: exc.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Author? author = await repository.GetById(id);

                return author is not null
                    ? Ok(author)
                    : NotFound();
            }
            catch (Exception exc)
            {
                logger.LogError(exc, $"Error while getting author by ID {id}");
                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: $"Error while getting author by ID {id}",
                    detail: exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAuthorDTO author)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError(
                    new ArgumentException("Invalid create author dto"),
                    $"Invalid create author DTO model state: {JsonConvert.SerializeObject(author, Formatting.Indented)}");
                return BadRequest(ModelState);
            }

            try
            {
                Author? created = await repository.Create(author);
                string url = $"{Request.Scheme}://{Request.Host}{Request.Path}";

                /* Created mi restituisce un 201 Created 
                 * indica che la richiesta è stata soddisfatta con successo 
                 * e ha portato alla creazione di una o più risorse.
                 */
                return created is not null
                    ? Created($"{url}/{created.Id}", created)
                    : BadRequest();

                /* in alternativa al Created posso utilizzare NoContent.
                 * Genera una risposta 204: "Nessun contenuto". 
                 * Questo codice significa che il server ha elaborato correttamente 
                 * la richiesta, ma non restituirà alcun contenuto.
                 *      return NoContent();
                 */
            }
            catch (Exception exc)
            {
                logger.LogError(exc, "Error while creating author");
                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Error while creating author",
                    detail: exc.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateAuthorDTO author)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError(
                    new ArgumentException("Invalid updating author dto"),
                    $"Invalid update author DTO model state: {JsonConvert.SerializeObject(author, Formatting.Indented)}");
                return BadRequest(ModelState);
            }

            try
            {
                Author? updated = await repository.Update(id, author);

                return updated is not null
                    ? Ok(updated)
                    : NotFound();
            }
            catch (Exception exc)
            {
                logger.LogError(exc, "Error while updating author");
                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Error while updating author",
                    detail: exc.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                bool deleted = await repository.Delete(id);

                return deleted
                    ? NoContent()
                    : NotFound();
            }
            catch (Exception exc)
            {
                logger.LogError(exc, "Error while deleting author");
                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Error while deleting author",
                    detail: exc.Message);
            }
        }
    }
}
