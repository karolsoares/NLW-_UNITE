using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Events : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredEventJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestEventJson request)
        {
            try
            {
                var useCase = new RegisterClassUseCases();

                var response = useCase.Execute(request);

                return Created(string.Empty , response);
            }
            catch (PassInExeption ex)
            {
                return BadRequest(new ResponseErrorJson(ex.Message));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Unknown error"));
            }


        }

        [HttpGet]
        [Route("{id")]
        [ProducesResponseType(typeof(ResponseRegisteredEventJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var useCase = new GetByIdUseCase();
                var response = useCase.Execute(id);
                return Ok(response);
            }
            catch (PassInExeption ex)
            {
                return NotFound(new ResponseErrorJson(ex.Message));

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorJson("Unknown error"));
            }
            
            
        }
    }
}
