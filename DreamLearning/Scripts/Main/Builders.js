var cardSchool = (school, address) => {
    if (address != null && school != null) {
        return `<li class="list-group-item mb-1 py-0 shadow-sm bg-white">
                            <div class="row" style="color:gray;">
                                <div class="col-12 col-sm-12 col-md-12 col-lg-9 col-xl-9">
                                    <span class="h5">Nome: </span>${school.Nome}
                                </div>
                                <div class="col-12 col-sm-12 col-md-12 col-lg-9 col-xl-9">
                                    <span class="h6">Abreviacao: </span>${school.AbreviacaoNome}
                                </div>
                                <div class="col-12 col-sm-12 col-md-12 col-lg-9 col-xl-9">
                                    <span class="h6">Telefone: </span>${school.Telefone}
                                </div>
                                <div class="col-12 col-sm-12 col-md-12 col-lg-9 col-xl-9">
                                    <span class="h6">Tipo: </span>${schoolType(school.Tipo.trim())}
                                </div>
                                <div class="col-12 col-sm-12 col-md-12 col-lg-3 col-xl-3 text-right">
                                </div>
                                <div class="col-12 pb-0 mb-0">
                                    <p class="text-muted mb-0">${ address.Logradouro}, ${address.Numero} - ${address.Bairro}</p>
                                    <small class="text-muted"><strong>CEP</strong>: ${address.Cep}</small>
                                </div>
                            </div>
                        </li>`;
    } else {
        return "";
    }
}

var cardAdress = (address, name) => {
    if (address != null) {
        $('#addressList').append(`<li class="list-group-item mb-1 py-0 shadow-sm bg-white">
                            <div class="row">
                                <div class="col-12 col-sm-12 col-md-12 col-lg-9 col-xl-9">
                                    <span class="h6">${ name}</span>
                                </div>
                                <div class="col-12 col-sm-12 col-md-12 col-lg-3 col-xl-3 text-right">
                                </div>
                                <div class="col-12 pb-0 mb-0">
                                    <p class="text-muted mb-0">${ address.Logradouro}, ${address.Numero} - ${address.Bairro}</p>
                                    <small class="text-muted"><strong>CEP</strong>: ${address.Cep}</small>
                                </div>
                            </div>
                        </li>`)
    }
}



let schoolType = (type) => {
    switch (type) {
        case "NI":
            return "Escola Conveniada";
        case "EDUCAÇÃO INFANTIL":
            return "Educação Infantil";
        case "ENSINO FUNDAMENTAL":
            return "Ensino Fundamental";
        case "EJA":
            return "Educação de Jovens e Adultos";
        default:
            return;
    }
}