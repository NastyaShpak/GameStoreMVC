function chooseOption() {
    let file = document.querySelector("#image_file").checked;
    let path = document.querySelector("#image_html").checked;
    let image_file = document.querySelector("#image");
    let image_path = document.querySelector(".my_image_id");
    if (file == true) {
        image_file.classList.remove("d-none");
        image_path.classList.add("d-none");
    } else if (path == true) {
        image_file.classList.add("d-none");
        image_path.classList.remove("d-none");
    }
}