(function (self, $, undefined) {

    var $btnBuscarTitulo = $("#btnBuscarTitulo"),
        $txtTitulo = $("#txtTitulo"),
        $detalle = $("#detalle"),
        $descripcion = $("#descripcion"),
        $tipo = $("#tipo"),
        $simbolo = $("#simbolo"),
        $moneda = $("#moneda"),
        $resumen = $("#resumen"),
        $detalleTitulo = $(".js-detalleTitulo");                

    self.inicializar = function () {
        
        //Botones  

        $btnBuscarTitulo.on("click", btnBuscarTitulo_Click);

        Autocomplete();

        GenerarResumen();
       
    };

    function Autocomplete() {

        $.ajax({
            type: "POST",
            url: CodingChallenge.Urls.buscarDescripcionesTitulos
        })
       .done(function (resultado) {

           if (resultado.TodoOk) {

               $txtTitulo.autocomplete({
                   source: resultado.descripciones
               });
           } else {
               // ERROR             
           }
       })
       .fail(function (jqXHR, textStatus) {
           //ALERT('adhasio');
       })
       .always(function () {           
       });           

    }

    function GenerarResumen() {
        var idioma = 2;

        $.ajax({
            type: "POST",
            url: CodingChallenge.Urls.generarResumen,
            data: {
                idiomaSelect: idioma,
            }  
        })
       .done(function (resultado) {

           if (resultado.TodoOk) {

               $resumen.html(resultado.resumen);

           } else {
               // ERROR             
           }
       })
       .fail(function (jqXHR, textStatus) {
           //ALERT('adhasio');
       })
       .always(function () {
       });
    }

    function btnBuscarTitulo_Click() {



        $.ajax({
            type: "POST",
            url: CodingChallenge.Urls.buscarDetallesTitulo,
            data: {
                descripcion: $txtTitulo.val(),
            }            
        })
       .done(function (resultado) {

           if (resultado.TodoOk) {
               
               $detalle.html(resultado.titulo.Detalle);
               $descripcion.html(resultado.titulo.Descripcion);
               $tipo.html(resultado.titulo.Tipo);
               $simbolo.html(resultado.titulo.Simbolo);
               $moneda.html(resultado.titulo.Moneda);

               $detalleTitulo.show();
               
           } else {
               // ERROR             
           }
       })
       .fail(function (jqXHR, textStatus) {
           //ALERT('adhasio');
       })
       .always(function () {
       });
    }

    function BuscarDeudas(autor) {
        $.ajax({
            type: "GET",
            url: CodingChallenge.Urls.buscarTitulo,
            data: {
                autor: autor
            }
        })
       .done(function (resultado) {

           if (resultado.TodoOk) {

               if (resultado.pendientes.length > 0) {
                   $btnAnterior.prop("disabled", false);
                   $btnSiguiente.prop("disabled", false);

                   deudas = resultado.pendientes;
               } else
                   deudas = [];

               return;
           } else {
               // Subi ERROR
               SitioCIAdmin.Helpers.mostrarDialogo("<h5 class='text-danger'>Error al hacer la consulta</h5>");
           }

       })
       .fail(function (jqXHR, textStatus) {
           SitioCIAdmin.Helpers.mostrarDialogo("<h5 class='text-danger'>Error al hacer la consulta</h5>");
       })
       .always(function () {
           $btnBuscarPersona.prop("disabled", false);
       });
    }

    function btnAutorizar_Click() {
        esBusqueda = false;

        $.ajax({
            type: "POST",
            url: SitioCIAdmin.Urls.aplicarAutorizaciones,
            contentType: 'application/json; charset=utf-8',            
            data: JSON.stringify( {
                listaRechazadas: deudasRechazadas,
                listaConfirmadas: deudasConfirmadas
            })
        })
      .done(function (resultado) {

          if (resultado.TodoOk) {

              SitioCIAdmin.Helpers.mostrarDialogo("<h5 class='text-success'>Autorizaciones aplicadas correctamente</h5>");

              LimpiarGrilla();
        
              var autor = $Usuarios.val();
              BuscarDeudas(autor);

              //LimpiarPantalla();

          } else {
              // Subi ERROR
              SitioCIAdmin.Helpers.mostrarDialogo("<h5 class='text-danger'>Error al hacer la consulta</h5>");
          }

      })
      .fail(function (jqXHR, textStatus) {
          SitioCIAdmin.Helpers.mostrarDialogo("<h5 class='text-danger'>Error al hacer la consulta</h5>");
      })
      .always(function () {
          $btnBuscarPersona.prop("disabled", false);
      });        
    }

    function LlenarGrilla(cuit, entidades) {

        
        // Sin resultados.
        if (esBusqueda) {
            if (lista.length === 0) {
                SitioCIAdmin.Helpers.mostrarDialogo("<h5 class='text-danger'>No se encontraron resultados</h5>");
                return;
            }
        }
        else {
            LimpiarGrilla();
        }

        $("#tblListadoDeudas .js-tmp-row").remove();

        $("[name='switch-confirmar']").bootstrapSwitch('destroy', true);
        $("[name='switch-rechazar']").bootstrapSwitch('destroy', true);

        $(lista).each(function (i, item) {

            var $tmp = $trTemplate.clone();
            $tmp.removeAttr("Id");
            $tmp.addClass("js-Listado-Deudas");
            $tmp.show();
            $tmp.find(".js-entidad").html(item.CodEntidad); //+ " - " + SitioCIAdmin.PersonaEntidad.ObtenerIdsEntidadesDescripcion(item.CodEntidad));
            $tmp.find(".js-periodo").html(item.Periodo);
            $tmp.find(".js-tipo-mov").html(item.Movimiento).prop("title", item.DetalleMovimiento.concat(" [" + item.Autor + "]"));
            $tmp.find(".js-situacion").html(item.Situacion).addClass("sit-".concat(item.Situacion));
            $tmp.find(".js-monto").html(item.Monto);
            $tmp.find(".js-motivo").html(item.Motivo);
            $tmp.find(".js-fecha-alta").html(item.FechaAlta);
            $tmp.data("id", item.Id);
            $tmp.data("idMovreq", item.Id);

            if (item.HayInforme) {
                $tmp.addClass("js-hayInforme");
            }

            $sinSolicitudes.hide();
            $("#tblListadoDeudas").find("tbody").append($tmp);
        });

    }


}(window.CodingChallenge = window.CodingChallenge || {}, jQuery));

jQuery(function () {
    window.CodingChallenge.inicializar();
});