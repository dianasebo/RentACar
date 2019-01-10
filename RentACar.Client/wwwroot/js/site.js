// const readUploadedFileAsText = async (inputFile) => {
    
async function readUploadedFilesAsText(inputFile) {
    var pictureList = inputFile.files;
    var pictures = [];
    for (var i = 0; i < pictureList.length && pictures.length < 10; i++) {
        if (pictureList[i].size < 1024 * 1024) {
            const temporaryFileReader = new FileReader();
            pictures.push(await new Promise((resolve, reject) => {
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
                temporaryFileReader.readAsDataURL(pictureList[i]);
            }));        
        }
    }
    return pictures;
};

async function getPicturesData(inputFile) {
    var expr = "#" + inputFile.replace(/"/g, '');
    return await readUploadedFilesAsText($(expr)[0]);
};

function toggleFilters() {
    var filters = document.getElementById("filters");
    if (filters.style.display === "none") {
        filters.style.display = "block";
    } else {
        filters.style.display = "none";
    }
}

function toggleModal(modalId) {
    $('#' + modalId).modal('toggle');
}