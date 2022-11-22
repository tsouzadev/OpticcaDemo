(function() {
    document.addEventListener('DOMContentLoaded', (event) => {

        let addIdeaForm = document.getElementById("add-idea-form-container");

        let cancelButton = document.getElementById("cancel-btn");
        cancelButton.addEventListener("click", (evt) => {
            addIdeaForm.style.display = "none";
        });

        let addIdeaButton = document.getElementById("add-idea-btn");
        addIdeaButton.addEventListener("click", (evt) => {
            addIdeaForm.style.display = "block";
        });

        //let deleteModal = document.getElementById("delete-modal");
        //let confirmDeleteId = document.getElementById("confirm-delete-id");
        //let deleteButtons = document.getElementsByClassName("delete-btn");
        //Array.from(deleteButtons).forEach(function (element) {
        //    element.addEventListener('click', (evt) => {
        //        let id = evt.target.getAttribute("data-id");

        //        confirmDeleteId.setAttribute("value", id);

        //        deleteModal.style.display = "block";
        //    });
        //});
    });
})();