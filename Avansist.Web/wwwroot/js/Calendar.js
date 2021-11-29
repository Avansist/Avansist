var calendar = null;
function calendario() {
    let formulario = document.querySelector("#formularioEvento");
    let calendario = document.getElementById("calendar");
    calendar = new FullCalendar.Calendar(calendario, {

        initialView: 'dayGridMonth',
        locale: 'es',
        buttonIcons: true,
        weekNumbers: true,
        navLinks: true,
        editable: false,
        dayMaxEvents: true,
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listMonth'
        },
        dateClick: function (info) {
            formulario.reset();
            $("#FechaInicioEvento").val(info.dateStr);
            $('#modalCalendario').modal('show');
        },
        eventClick: function (info) {
            $.ajax({
                url: '/Home/Edit/' + info.event.id,
                type: 'get'
            }).done(function (respuesta) {
                $('#AgendaId').val(respuesta.data.agendaId);
                $('#Direccion').val(respuesta.data.direccion);
                $('#EmpleadoEncargado').val(respuesta.data.empleadoEncargado);
                $('#NombreEvento').val(respuesta.data.nombreEvento);
                $('#NumeroDocumento').val(respuesta.data.numeroDocumento);
                $('#Telefono').val(respuesta.data.telefono);
                $('#HoraInicioEvento').val(respuesta.data.horaInicioEvento);
                $('#HoraFinEvento').val(respuesta.data.horaFinEvento);
                $('#FechaInicioEvento').val(moment(respuesta.data.fechaInicioEvento).format("YYYY-MM-DD"));
                //$('#FechaFinEvento').val(moment(respuesta.data.fechaFinEvento).format("YYYY-MM-DD"));
                $('#Editar').css('display', 'block');

                $('#modalCalendario').modal('show');
            })
        }
    });
    calendar.render();
}


function guardar() {
    let formData = new FormData();

    formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento").value).format("YYYY-MM-DD"));
    //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
    formData.append("Direccion", document.getElementById("Direccion").value);
    formData.append("NombreEvento", document.getElementById("NombreEvento").value);
    formData.append("Telefono", document.getElementById("Telefono").value);
    formData.append("NumeroDocumento", document.getElementById("NumeroDocumento").value);
    formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado").value);
    formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento").value);
    formData.append("HoraFinEvento", document.getElementById("HoraFinEvento").value);

    $.ajax({
        url: '/Home/Create',
        type: 'post',
        processData: false,
        contentType: false,
        data: formData,
        dataType: 'json'
    }).done(function (respuesta) {
        if (respuesta.status) {
            alertify.success('Guardado');
            setTimeout(function () {
                window.location.href = '/Home/Index';
            }, 700);
            //document.location.reload();
            $('#modalCalendario').modal('hide');
        }
    })
}

function listar() {
    $.ajax({
        url: '/Home/Listar',
        type: 'get',
        dataType: 'json'
    }).done(function (respuesta) {
        if (respuesta.status) {
            let data = [];
            respuesta.data.map(function (e) {
                data.push({
                    id: e.agendaId,
                    title: e.nombreEvento,
                    start: moment(e.fechaInicioEvento).format("YYYY-MM-DD") + " " + e.horaInicioEvento,
                    end: moment(e.fechaInicioEvento).format("YYYY-MM-DD") + " " + e.horaFinEvento
                });
            });
            calendar.addEventSource(data);
        }
    })
}

function editar() {
    let formData = new FormData();

    formData.append("AgendaId", document.getElementById("AgendaId").value);
    formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento").value).format("YYYY-MM-DD"));
    //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
    formData.append("Direccion", document.getElementById("Direccion").value);
    formData.append("NombreEvento", document.getElementById("NombreEvento").value);
    formData.append("Telefono", document.getElementById("Telefono").value);
    formData.append("NumeroDocumento", document.getElementById("NumeroDocumento").value);
    formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado").value);
    formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento").value);
    formData.append("HoraFinEvento", document.getElementById("HoraFinEvento").value);

    $.ajax({
        url: '/Home/Edit/' + document.getElementById("AgendaId").value,
        type: 'post',
        processData: false,
        contentType: false,
        data: formData,
        dataType: 'json'
    }).done(function (respuesta) {
        if (respuesta.status) {
            alertify.success('Guardado');
            setTimeout(function () {
                window.location.href = '/Home/Index';
            }, 700);
            $('#modalCalendario').modal('hide');
        }        
    })
}

function eliminar() {
    Swal.fire({
        text: '¿Desea eliminar el registro?',
        icon: 'error',
        confirmButtonColor: '#afdb6e',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Aceptar',
        denyButtonText: 'Cancelar',
    }).then((result) => {
        if (result.isConfirmed) {
            let formData = new FormData();

            formData.append("AgendaId", document.getElementById("AgendaId").value);
            formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento").value).format("YYYY-MM-DD"));
            //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
            formData.append("Direccion", document.getElementById("Direccion").value);
            formData.append("NombreEvento", document.getElementById("NombreEvento").value);
            formData.append("Telefono", document.getElementById("Telefono").value);
            formData.append("NumeroDocumento", document.getElementById("NumeroDocumento").value);
            formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado").value);
            formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento").value);
            formData.append("HoraFinEvento", document.getElementById("HoraFinEvento").value);            

            $.ajax({
                url: '/Home/Delete/' + document.getElementById("AgendaId").value,
                type: 'get',
                processData: false,
                contentType: false,
                data: formData,
                dataType: 'json',
                success: function (result) {
                    if (result.status == true) {
                        setTimeout(function () {
                            window.location.href = '/Home/Index';
                        }, 700);
                        alertify.success('Eliminado');
                        $('#modalCalendario').modal('hide');
                    } else {
                        alertify.error('No se pudo eliminar');
                    }
                },
                error: function (err) {
                    console.log(err.data);
                }
            });
        } else if (result.isDenied) {
            alertify.error('Cancelado');
        }
    })    
}


/*
    Metodos para agendar cita del beneficiario
 */


//function guardarCitaBeneficiario() {
//    let formData = new FormData();

//    //formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento").value).format("YYYY-MM-DD"));
//    //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
//    formData.append("NombreBeneficiario", document.getElementById("NombreBeneficiario").value);
//    //formData.append("NombreEvento", document.getElementById("NombreEvento").value);
//    //formData.append("Telefono", document.getElementById("Telefono").value);
//    //formData.append("NumeroDocumento", document.getElementById("NumeroDocumento").value);
//    //formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado").value);
//    //formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento").value);
//    //formData.append("HoraFinEvento", document.getElementById("HoraFinEvento").value);

//    $.ajax({
//        url: '/Beneficiario/Preinscripcion/CreateAgendaBeneficiario/' + document.getElementById("BeneficiarioId").value,
//        type: 'get',
//        processData: false,
//        contentType: false,
//        data: formData,
//        dataType: 'json'
//    }).done(function (respuesta) {
//        if (respuesta.status) {
//            alert("Se guardo");
//            document.location.reload();
//            $('#modalCalendario').modal('hide');
//        }
//    })
//}