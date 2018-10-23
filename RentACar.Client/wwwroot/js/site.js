const readUploadedFileAsText = (inputFile) => {
    const temporaryFileReader = new FileReader();
    return new Promise((resolve, reject) => {
        temporaryFileReader.onerror = () => {
            temporaryFileReader.abort();
            reject(new DOMException("Problem parsing input file."));
        };
        temporaryFileReader.addEventListener("load", function () {
            var data = {
                content: temporaryFileReader.result.split(',')[1]
            };
            resolve(data);
        }, false);
        temporaryFileReader.readAsDataURL(inputFile.files[0]);
    });
};

function getFileData(inputFile) {
    var expr = "#" + inputFile.replace(/"/g, '');
    return readUploadedFileAsText($(expr)[0]);
};

function toggleFilters() {
    var filters = document.getElementById("filters");
    if (filters.style.display === "none") {
        filters.style.display = "block";
    } else {
        filters.style.display = "none";
    }
}