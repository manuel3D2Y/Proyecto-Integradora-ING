$(document).ready(function () {
    obtenerFechaActual();
    cargarAlumnos();
    cargarMaterias();
    consultar();
});

var claveActualizar = undefined;
//alamacena las fases del proyecto a nivel global

function cargarAlumnos() {
    $.ajax({
        url: '/Escuela/CargarAlumnos',
        type: 'POST',
        data: JSON.stringify(),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            debugger;
            //obtiene la lista de proyectos
            var lstAlumnos = data.lista;
            //Limpia el combo
            $("#selecAlumno").empty();
            //Agrega las opciones 
            $("#selecAlumno").append(new Option("--Nombre del alumno--", "-1"));
            if (lstAlumnos != null) {
                for (var i = 0; i < lstAlumnos.length; i++) {
                    $("#selecAlumno").append(new Option(lstAlumnos[i].NombreAlunno + " " + lstAlumnos[i].App + " " + lstAlumnos[i].Apm, lstAlumnos[i].ClaveAlumno));
                }
            }

            //Una vez cargados los proyectos debe cargar las fases del proyecto
            //cargarFases();
        },
        error: function (result) {
            console.log(JSON.stringify(result));
            alert("Ocurrió un error al consultar los alumnos");
        }
    });
}

function cargarMaterias() {
    $.ajax({
        url: '/Escuela/CargarMaterias',
        type: 'POST',
        data: JSON.stringify(),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            debugger;
            //obtiene la lista de proyectos
            var lstMaterias = data.lista;
            //Limpia el combo
            $("#selecMateria").empty();
            //Agrega las opciones 
            $("#selecMateria").append(new Option("--Nombre de la materia--", "-1"));
            if (lstMaterias != null) {
                for (var i = 0; i < lstMaterias.length; i++) {
                    $("#selecMateria").append(new Option(lstMaterias[i].NombreMateria, lstMaterias[i].IdMateria));
                }
            }

            //Una vez cargados los proyectos debe cargar las fases del proyecto
            //cargarFases();
        },
        error: function (result) {
            console.log(JSON.stringify(result));
            alert("Ocurrió un error al consultar los alumnos");
        }
    });
}

function consultar() {
    $.ajax({
        url: '/Escuela/Consultar',
        type: 'POST',
        data: JSON.stringify(),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            console.log(JSON.stringify(data));
            okPintarConsulta(data);
        },
        error: function (result) {
            console.log(JSON.stringify(result));
            alert("Ocurrió un error al consultar las calificaciones");
        }
    });
}

function okPintarConsulta(data) {
    var lstRegistros = data.lista;
    console.log('lstRegistros', JSON.stringify(lstRegistros));
    $("#tblCalificaiones > tbody > tr").empty();
    //limpiarCampos();
    if (lstRegistros != null) {
        debugger;
        //Recorre la lista y al mismo tiempo los va insertando a la tabla
        for (var i = 0; i < lstRegistros.length; i++) {
            var row = "<tr>";
            row += "<td  style='display:block;'>";
            row += lstRegistros[i].IdA;
            row += "</td><td>";
            row += lstRegistros[i].IdM;
            row += "</td><td>";
            row += lstRegistros[i].IdM;
            row += "</td><td>";
            row += lstRegistros[i].Calif1;
            row += "</td><td>";
            row += lstRegistros[i].Calif2;
            row += "</td><td>";
            row += lstRegistros[i].Calif3;
            row += "</td><td>";
            row += lstRegistros[i].Calif4;
            row += "</td><td>";
            row += lstRegistros[i].Califf;
            row += "</td><td>";
            row += lstRegistros[i].Ano;
            row += "</td><td>";
            row += lstRegistros[i].Periodo;
            row += "</td><td>";
            row += "<span id=" + lstRegistros[i].MiClave + " onclick='eliminar(this.id)' class='glyphicon glyphicon-trash' aria-hidden='true'></span>";
            row += "</td><td>";
            row += "<span id=" + lstRegistros[i].MiClave + " onclick='recuperarValores(this.id)' class='glyphicon glyphicon-pencil' aria-hidden='true' data-toggle=\"modal\" data-target=\"#miModal\"></span>";
            row += "</td></tr>";

            $("#tblCalificaiones > tbody").append(row);
        }
    }

}

function recuperarValores(id) {
    claveActualizar = id;

    debugger;
    var parametros = {
        MiClave: parseInt(id)
    }

    $.ajax({
        url: '/Escuela/Recuperar',
        type: 'POST',
        data: JSON.stringify(parametros),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            console.log(JSON.stringify(data));
            //llena los datos
            var lstRegistros = data.lista;
            //$("#selecAlumno").val()=
            //ID_M: $("#selecMateria").val(),
            $("#Calificacion1").val(lstRegistros.calif_1);
            $("#Calificacion2").val(lstRegistros.calif_2);
            $("#Calificacion3").val(lstRegistros.calif_3);
            $("#Calificacion4").val(lstRegistros.calif_4);
            $("#CalificacionFinal").val(lstRegistros.calif_f);
            $("#Anio").val(lstRegistros.ano);
            $("#Periodo").val(lstRegistros.Periodo);

        },
        error: function (result) {
            console.log(JSON.stringify(result));
            alert("Ocurrio un error al recuperar los valores");
        }
    });
}

//Obtiene la fecha actual
function obtenerFechaActual() {
    var f = new Date();
    var mes = undefined;
    var dia = undefined;
    if ((f.getMonth() + 1) < 10) {
        mes = "0" + (f.getMonth() + 1);
    } else {
        mes = (f.getMonth() + 1);
    }

    if ((f.getDate()) < 10) {
        dia = "0" + (f.getDate());
    } else {
        dia = (f.getDate());
    }
    var fecha = dia + "-" + mes + "-" + f.getFullYear();
    $("#fechaHoy").html(fecha);
}

//Inserta responsables a l proyecto seleccionado
function agregar() {
    var todoBien = true;
    var mensajeError = "";
    var requerido = "";
    var parametros = {
        //MiClave: parseInt(id),
        Id_A: $("#selecAlumno").val(),
        ID_M: $("#selecMateria").val(),
        calif_1: $("#txtCalificacion1").val(),
        calif_2: $("#txtCalificacion2").val(),
        calif_3: $("#txtCalificacion3").val(),
        calif_4: $("#txtCalificacion4").val(),
        calif_f: $("#txtCalificacionFinal").val(),
        ano: $("#txtAnio").val(),
        Periodo: $("#txtPeriodo").val()
    }

    //Sí las validaciones se cumplen entonces prosede con el registro de Satkeholders
    if (todoBien) {
        $.ajax({
            url: '/Escuela/Agregar',
            type: 'POST',
            data: JSON.stringify(parametros),
            dataType: 'JSON',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert("Registro agregado con éxito");
                limpiarCampos();
                consultar();
            },
            error: function (result) {
                alert("Ocurrio un error en el registro");
            }
        });
    } else {
        alert(mensajeError);
    }
}

function eliminar(id) {
    debugger;
    var parametros = {
        MiClave: parseInt(id)
    }

    $.ajax({
        url: '/Escuela/Eliminar',
        type: 'POST',
        data: JSON.stringify(parametros),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            alert("Se ha eliminado el registro");
            console.log(JSON.stringify(data));
            consultar();
        },
        error: function (result) {
            console.log(JSON.stringify(result));
            alert("Ocurrio un error al eliminar");
        }
    });
}

function actualizar() {
    var todoBien = true;
    var mensajeError = "";
    var requerido = "";

    var parametros = {
        MiClave: parseInt(claveActualizar),
        Id_A: $("#selecAlumno").val(),
        ID_M: $("#selecMateria").val(),
        calif_1: $("#Calificacion1").val(),
        calif_2: $("#Calificacion2").val(),
        calif_3: $("#Calificacion3").val(),
        calif_4: $("#Calificacion4").val(),
        calif_f: $("#CalificacionFinal").val(),
        ano: $("#Anio").val(),
        Periodo: $("#Periodo").val()
    }


    if (todoBien) {
        $.ajax({
            url: '/Escuela/Actualizar',
            type: 'POST',
            data: JSON.stringify(parametros),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert("Se ha actualizado el registro");
                console.log(JSON.stringify(data));
                consultar();
                $('#miModal').modal('toggle');
                //limpia la variable global
                claveActualizar = undefined;
            },
            error: function (result) {
                console.log(JSON.stringify(result));
                alert("Ocurrio un error al atualizar");
            }
        });
    } else {
        alert(mensajeError);
    }
}

//Limpia lso campos de stakeholders
function limpiarCampos() {
    $("#selecMateria").val(-1);
    $("#selecAlumno").val(-1);
    $("#txtCalificacion1").val("");
    $("#txtCalificacion2").val("");
    $("#txtCalificacion3").val("");
    $("#txtCalificacion4").val("");
    $("#txtCalificacionFinal").val("");
    $("#txtAnio").val("");
    $("#txtPeriodo").val("");
}

function calcularPromedio() {
    var promedio= undefined;
    promedio = (parseFloat($("#txtCalificacion1").val()) +
                parseFloat($("#txtCalificacion2").val()) +
                parseFloat($("#txtCalificacion3").val()) +
                parseFloat($("#txtCalificacion4").val()))/4;

    $("#txtCalificacionFinal").val(promedio);
}

function calcularPromedioModal() {
    var promedio = undefined;
    promedio = (parseFloat($("#Calificacion1").val()) +
        parseFloat($("#Calificacion2").val()) +
        parseFloat($("#Calificacion3").val()) +
        parseFloat($("#Calificacion4").val()))/4;

    $("#CalificacionFinal").val(promedio);
}