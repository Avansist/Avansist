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
                $('#AgendaId1').val(respuesta.data.agendaId);
                $('#Direccion1').val(respuesta.data.direccion);
                $('#EmpleadoEncargado1').val(respuesta.data.empleadoEncargado);
                $('#NombreEvento1').val(respuesta.data.nombreEvento);
                $('#NumeroDocumento1').val(respuesta.data.numeroDocumento);
                $('#Telefono1').val(respuesta.data.telefono);
                $('#HoraInicioEvento1').val(respuesta.data.horaInicioEvento);
                $('#HoraFinEvento1').val(respuesta.data.horaFinEvento);
                $('#FechaInicioEvento1').val(moment(respuesta.data.fechaInicioEvento).format("YYYY-MM-DD"));
                //$('#FechaFinEvento').val(moment(respuesta.data.fechaFinEvento).format("YYYY-MM-DD"));
                $('#Editar').css('display', 'block');

                $('#modalCalendario2').modal('show');
            })
        }
    });
    calendar.render();
}



document.getElementById("btn-guardar").addEventListener("click", function (event) {
    if (!$("#formularioEvento").valid()) {
        $("label.error").css("color", "red");
        $("label.error").css("font-weight", "300");

        event.preventDefault();

    } else {
        let state = true;

        if ($($("#HoraInicioEvento").val() != null && $("#HoraFinEvento").val() != null)) {
            if ($("#HoraInicioEvento").val() && $("#HoraInicioEvento").val() >= $("#HoraFinEvento").val()) {
                event.preventDefault();
                alertify.alert('Formato no permitido','La hora de termino del evento, no puede ser igual o menor que la hora de inicio del evento');
                state = false;
            }

        }

        if (state === true) {

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
                if (respuesta.status == true) {
                    alertify.success('Guardado');
                    setTimeout(function () {
                        window.location.href = '/Home/Index';
                    }, 700);
                    //document.location.reload();
                    $('#modalCalendario').modal('hide');
                } else {
                    alertify.alert('No se pudo guardar, compruebe el formulario');
                }
            })
        }
    }

    
})

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

document.getElementById("btn-editar").addEventListener("click", function (event) {
    if (!$("#formularioEvento2").valid()) {
        $("label.error").css("color", "red");
        $("label.error").css("font-weight", "300");

        event.preventDefault();

    } else {
        let state = true;

        if ($($("#HoraInicioEvento1").val() != null && $("#HoraFinEvento1").val() != null)) {
            if ($("#HoraInicioEvento1").val() && $("#HoraInicioEvento1").val() >= $("#HoraFinEvento1").val()) {
                event.preventDefault();
                alertify.alert('No permitido!', 'La hora de fin del evento, no puede ser igual o menor que la hora de inicio del evento');
                state = false;
            }

        }

        if (state === true) {

            let formData = new FormData();

            formData.append("AgendaId", document.getElementById("AgendaId1").value);
            formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento1").value).format("YYYY-MM-DD"));
            //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
            formData.append("Direccion", document.getElementById("Direccion1").value);
            formData.append("NombreEvento", document.getElementById("NombreEvento1").value);
            formData.append("Telefono", document.getElementById("Telefono1").value);
            formData.append("NumeroDocumento", document.getElementById("NumeroDocumento1").value);
            formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado1").value);
            formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento1").value);
            formData.append("HoraFinEvento", document.getElementById("HoraFinEvento1").value);

            $.ajax({
                url: '/Home/Edit/' + document.getElementById("AgendaId").value,
                type: 'post',
                processData: false,
                contentType: false,
                data: formData,
                dataType: 'json'
            }).done(function (respuesta) {
                if (respuesta.status == true) {
                    setTimeout(function () {
                        window.location.href = '/Home/Index';
                    }, 700);
                    $('#modalCalendario2').modal('hide');
                    alertify.success('Actualizado');
                } else {
                    alertify.alert('No se pudo actualizar, compruebe el formulario');
                }
            })
        }
    }


})

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

            formData.append("AgendaId", document.getElementById("AgendaId1").value);
            formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento1").value).format("YYYY-MM-DD"));
            //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
            formData.append("Direccion", document.getElementById("Direccion1").value);
            formData.append("NombreEvento", document.getElementById("NombreEvento1").value);
            formData.append("Telefono", document.getElementById("Telefono1").value);
            formData.append("NumeroDocumento", document.getElementById("NumeroDocumento1").value);
            formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado1").value);
            formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento1").value);
            formData.append("HoraFinEvento", document.getElementById("HoraFinEvento1").value);

            $.ajax({
                url: '/Home/Delete/' + document.getElementById("AgendaId1").value,
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
                        $('#modalCalendario2').modal('hide');
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
    Metodos para agendar cita del beneficiario (Reciclaje)
 */

//function editar() {
//    let formData = new FormData();

//    formData.append("AgendaId", document.getElementById("AgendaId1").value);
//    formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento1").value).format("YYYY-MM-DD"));
//    //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
//    formData.append("Direccion", document.getElementById("Direccion1").value);
//    formData.append("NombreEvento", document.getElementById("NombreEvento1").value);
//    formData.append("Telefono", document.getElementById("Telefono1").value);
//    formData.append("NumeroDocumento", document.getElementById("NumeroDocumento1").value);
//    formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado1").value);
//    formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento1").value);
//    formData.append("HoraFinEvento", document.getElementById("HoraFinEvento1").value);

//    $.ajax({
//        url: '/Home/Edit/' + document.getElementById("AgendaId").value,
//        type: 'post',
//        processData: false,
//        contentType: false,
//        data: formData,
//        dataType: 'json'
//    }).done(function (respuesta) {
//        if (respuesta.status == true) {
//            setTimeout(function () {
//                window.location.href = '/Home/Index';
//            }, 700);
//            $('#modalCalendario2').modal('hide');
//            alertify.success('Actualizado');
//        } else {
//            alertify.alert('No se pudo actualizar, compruebe el formulario');
//        }
//    })
//}

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

//function guardar(e) {

//    console.log(e);
//    this.e = e;

//    let state = true;

//    if ($($("#HoraInicioEvento").val() != null && $("#HoraFinEvento").val() != null)){
//        if ($("#HoraInicioEvento").val() && $("#HoraInicioEvento").val() >= $("#HoraFinEvento").val()) {
//            e.preventDefault();
//            alert("la hora de termino, no puede ser igual o menor que la hora de inicio")
//            state = false;
//        }

//    } else {
//        e.preventDefault();
//        alert("Debe completar ambas fechas");
//        state = false;
//    }

//    if (state === true) {

//        let formData = new FormData();

//        formData.append("FechaInicioEvento", moment(document.getElementById("FechaInicioEvento").value).format("YYYY-MM-DD"));
//        //formData.append("FechaFinEvento", moment(document.getElementById("FechaFinEvento").value).format("YYYY-MM-DD"));
//        formData.append("Direccion", document.getElementById("Direccion").value);
//        formData.append("NombreEvento", document.getElementById("NombreEvento").value);
//        formData.append("Telefono", document.getElementById("Telefono").value);
//        formData.append("NumeroDocumento", document.getElementById("NumeroDocumento").value);
//        formData.append("EmpleadoEncargado", document.getElementById("EmpleadoEncargado").value);
//        formData.append("HoraInicioEvento", document.getElementById("HoraInicioEvento").value);
//        formData.append("HoraFinEvento", document.getElementById("HoraFinEvento").value);

//        $.ajax({
//            url: '/Home/Create',
//            type: 'post',
//            processData: false,
//            contentType: false,
//            data: formData,
//            dataType: 'json'
//        }).done(function (respuesta) {
//            if (respuesta.status == true) {
//                alertify.success('Guardado');
//                setTimeout(function () {
//                    window.location.href = '/Home/Index';
//                }, 700);
//                //document.location.reload();
//                $('#modalCalendario').modal('hide');
//            } else {
//                alertify.alert('No se pudo guardar, compruebe el formulario');
//            }
//        })
//    }
//}