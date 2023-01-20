jQuery(function ($) {
    $("input[name=cep]").change(function () {
        var cep_code = $(this).val();
        if (cep_code.Length <= 0) return;
        $.get("https://cdn.apicep.com/file/apicep/cep.json", { code: cep_code }, function (result) {
            if (result.status != 200) {
                alert(result.message || "Cep não encontrado");
                return;
            }
            $("input[name=cep]".val(result.code))
            $("input[name=estado]".val(result.state))
            $("input[name=cidade]".val(result.city))
            $("input[name=bairro]".val(result.district))
            $("input[name=endereco]".val(result.adress))
        });
    });
});