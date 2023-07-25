function validateForm() {
    var image = document.getElementById("image").value;
    var imageLink = document.getElementById("imageLink").value;

    if (image == "" && imageLink == "") {
        alert("Please upload an image or enter an image link.");
        return false;
    }
}