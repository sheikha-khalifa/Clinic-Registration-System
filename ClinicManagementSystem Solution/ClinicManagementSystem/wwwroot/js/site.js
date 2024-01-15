// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var specializationDropdown = document.querySelector("#Spec");
var doctorDropdown = document.querySelector("#doc");

specializationDropdown.addEventListener('change', function () {
    var specializationID = specializationDropdown.value;


    fetch(`/Patient/GetDocInSpec?id=${specializationID}`)
        .then(response => response.json())
        .then(data => {
            
            doctorDropdown.innerHTML = '<option value="">-- Select Doctors --</option>';

            
            data.forEach(doctor => {
                var option = document.createElement('option');
                option.value = doctor.doctorId;
                option.text = doctor.name;
                doctorDropdown.add(option);
            });
        })
        .catch(error => {
            console.error('Error fetching doctors:', error);
        });
});