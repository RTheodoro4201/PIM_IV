using Microsoft.AspNetCore.Mvc;
using PIM_IV.Models;

namespace PIM_IV.Abstract;

public interface IValidator
{
    protected bool ValidateModel(Object model);
}