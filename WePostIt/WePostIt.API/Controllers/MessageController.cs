using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using WePostIt.API.DTOs;

namespace WePostIt.API.Controllers
{
    /* ApiControllerAttribute:
     * I controllers decorati con questo attributo sono trattati come 
     * controllers con comportamento API.
     * href="https://learn.microsoft.com/aspnet/core/web-api/#apicontroller-attribute"
     */
    [ApiController]
    /* RouteAttribute:
     * Specifica la rotta del controller
     * es. [Route("[controller]")] -> la route del controller sarà:
     *      https://localhost:7073/message/...
     * es. [Route("your-messages")] -> la route del controller sarà:
     *      https://localhost:7073/your-messages/...
     */
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> logger;

        public MessageController(ILogger<MessageController> logger)
        {
            this.logger = logger;
        }

        /* posso definire piú di una rotta che punta alla stessa action 
         * es. [Route("[action]")] -> // https://localhost:7073/message/GetAllAsync
         * es. [Route("all")] -> // https://localhost:7073/message/all
         * sono rotte diverse che puntano alla stessa action
         * è importante che un URL identifichi una ed una sola risorsa, univoca.
         * in questo caso 2 URL puntano alla stessa risorsa, ma ciascun URL
         * punta a una sola risorsa
         */
        [HttpGet]
        [Route("[action]")] // https://localhost:7073/message/all
        [Route("all")] // https://localhost:7073/message/all
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exc) 
            {
                string logMessage = $"Error getting messages";
                
                LogError(logMessage, exc);
                
                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    title: logMessage,
                    detail: exc.Message);
            }
        }

        [HttpGet]
        /* il primo parametro del RouteAttribute è il template del path.
         * in questo caso sto indicato che il path deve essere composto anche
         * dall'id del messaggio, che deve essere di tipo int
         * in questo caso l'url è: https://localhost:7073/message/12345
         * definendo [Route("{id:int}")] non devo aggiungere per forza l'attributo
         * FromRouteAttribute affianco al parametro.
         * N.B.: se non definisco un parametro in path di default è come se
         * fosse marcato con l'attributo FromQuery (che recupera il parametro 
         * dalla query string
         * N.B.: FromRoute e FromQuery possono convivere
         * es. 
         *     path: https://localhost:7073/message/150?creationDate=2024-03-05
         *     def. method:
         *         [Route("filter/{authorId:int}")]
         *         public async Task<IActionResult> FilterByAuthorAndDate(
         *             [FromRoute] int authorId, 
         *             [FromQuery] DateTime creationDate)
         *     FromRoute e FromQuery sono opzionali, posso anche definire il metodo così:
         *         [Route("filter/{authorId:int}")]
         *         public async Task<IActionResult> FilterByAuthorAndDate(
         *             int authorId, 
         *             DateTime creationDate)
         * N.B.: posso marcare un parametro sia come in path che come query parameter...
         * es. 
         *     path: https://localhost:7073/Message/56?id=23
         *     def. metodo:
         *         [Route("{id:int}")]
         *         public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
         *     in questo caso il valore del parametro id sarà 23, perchè il parametro
         *     in query string sovrascrive quello in path
         * non ha nessuna utilità, è una pessima strategia di sviluppo e può 
         * causare bug 
         */
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception exc)
            {
                string logMessage = $"Error getting message - ID {id}";
                
                LogError(logMessage, exc);
                
                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    title: $"Error while getting message - ID {id}",
                    detail: exc.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        /* ConsumesAttribute:
         * definisce i content-type accettati nel body della richiesta.
         * es. [Consumes("application/json")] avrebbe accettato solo json
         * Consumes non è obbligatorio
         */
        [Consumes("application/xml", "application/json")]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateMessageDTO createMessageDTO)
        {
            if (!ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(createMessageDTO, Formatting.Indented);
                LogError($"Error creating message - invalid model state: {json}");

                return BadRequest(ModelState);
            }

            try
            {
                throw new NotImplementedException();
            }
            catch(Exception exc)
            {
                string logMessage = "Error creating new message";
                LogError(logMessage, exc);

                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    title: logMessage,
                    detail: exc.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync()
        {
            try
            {
                throw new NotImplementedException ();
            }
            catch (Exception exc)
            {
                string logMessage = "Error updating message";
                LogError(logMessage, exc);

                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    title: logMessage,
                    detail: exc.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exc)
            {
                string logMessage = "Error deleting message";
                LogError(logMessage, exc);

                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    title: logMessage,
                    detail: exc.Message);
            }
        }

        private void LogError(string message, Exception? exc = null)
        {
            logger.LogError(message, exc);
        }
    }
}
