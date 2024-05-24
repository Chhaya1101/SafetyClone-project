$(document).ready(function () {
    $("#loginenroll").blur(function () {
        $("#TxtloginenrollValidation").empty();
        $("#TxtloginenrollValidation").html("(*) EmailId is required..!!");
        TxtEnrollIdFlag = false;
    });
    $("#loginpassword").blur(function () {
        $("#TxtloginpasswordValidation").empty();
        $("#TxtloginpasswordValidation").html("(*) Password is required..!!");
        TxtPassIdFlag = false;
    });
    $("#OrgSelect").blur(function () {
        $("#OrganisationValidation").empty();
        $("#OrganisationValidation").html("(*) Organisation Selection is required..!!");
        TxtOrgIdFlag = false;
    });


    // formadata[];


    // email: $('#loginenroll').val();
    // password: $('#loginpassword').val();
    //org: $('#OrgSelect').val()

    //FetchData()
    //  .then(formData => {

    $('#loginBtn').click(function () {
        let TxtEnrollIdFlag = true;
        let TxtPassIdFlag = true;
        let TxtOrgIdFlag = true;

        $("#TxtloginenrollValidation").empty();
        if ($("#loginenroll").val() == "") {
            $("#TxtloginenrollValidation").html("(*) Email id required..!!");
            TxtEnrollIdFlag = false;
        }

        $("#TxtloginpasswordValidation").empty();
        if ($("#loginpassword").val() == "") {
            $("#TxtloginpasswordValidation").html("(*) Password required..!!");
            TxtPassIdFlag = false;
        }
        $("#OrganisationValidation").empty();
        if ($("#OrgSelect").val() == "") {
            $("#OrganisationValidation").html("(*) organisation selection  required..!!");
            TxtOrgIdFlag = false;
        }

        if (TxtEnrollIdFlag && TxtPassIdFlag && TxtOrgIdFlag) {
            let formData = {
                email: $("#loginenroll").val(),
                password: $("#loginpassword").val(),
                org: $("#OrgSelect").val()

            };
            $.ajax({
                url: `https://localhost:7105/api/UserLogin/GetValue?email=${formData.email}&password=${formData.password}&org=${formData.org}`,
                type: 'GET',
                dataType: 'json',
                success: function (responsedata) {
                    let users = responsedata.data;

                    $('#toast').removeClass('toast-warning toast-primary toast-danger').addClass('toast-success').toast('show');
                    $('.toast-body').text('login Successful');
                    // Set cookies for email, password, and role
                    document.cookie = `userId=${users[0].id}; path = /`;
                    document.cookie = `email=${formData.email}; path=/`;
                    document.cookie = `password=${formData.password}; path=/`;
                    document.cookie = `role=${users[0].roleName}; path=/`;


                    setTimeout(function () {

                        if (formData.org === "1" && users[0].roleName === 'Principle') {
                            // Redirect to Manage Subjects page
                            window.location.href = '/College/CreateCertificate';
                        } else if (formData.org === "2" && users[0].roleName === 'Admin') {
                            // Redirect to Menu/Index page
                            window.location.href = '/Company/adminpage';
                        }
                        else if (formData.org === "2" && users[0].roleName === 'Hr') {
                            window.location.href = '/Company/hrpage';
                        }
                        else if (formData.org === "2" && users[0].roleName === 'TeamLead') {
                            window.location.href = '/Company/teamleadpage';
                        }
                        else if (formData.org === "2" && users[0].roleName === 'Manager') {
                            window.location.href = '/Company/managerpage';
                        }
                        else {
                            window.location.href = '/Index';
                        }
                        $('#login-form').trigger('reset');

                    }, 1000);


                },
                error: function (error) {
                    $('#toast').removeClass('toast-warning toast-primary toast-danger toast-success').addClass('toast-warning').toast('show');
                    $('.toast-body').text('password incorrect');

                }
            })
               
            
           
        }
    });
});


   
