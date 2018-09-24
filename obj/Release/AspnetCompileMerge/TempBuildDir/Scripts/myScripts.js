$(document).ready(function () {

    $("#browseBtn").change(checkFile);
});

var checkFile = function ()
{
    var isValidFile = false;
    if ($(this).val().search(".xlsx$") != -1) {
        $("#uploadBtn").css("visibility", "visible");
        isValidFile = true;
        
    }
        var message;

        if ($("img").is("#checkImg")) {
            $("#checkDiv").empty();
        }

        var resultImage = document.createElement("img");
        var resultMessage = document.createElement("p");

        resultImage.setAttribute("id", "checkImg");
        resultMessage.setAttribute("id", "checkMess");

        if (isValidFile) {
            resultImage.setAttribute("src", "../Images/valid.png");
            message = document.createTextNode("Your file is ready for upload.");
        }
        else {
            resultImage.setAttribute("src", "../Images/invalid.png");
            message = document.createTextNode("Your have chosen invalid file, please choose suitable file.");

            $("#uploadBtn").css("visibility", "hidden");
        }

        resultMessage.append(message);
        $("#checkDiv").append(resultImage, resultMessage);
}