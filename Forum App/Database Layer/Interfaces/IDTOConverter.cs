using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Layer.Interfaces
{
    public interface IDTOConverter<DTO, Model>
    {
        Model DtoToModel(DTO dto);
        DTO ModelToDTO(Model model);
    }
}
