window.showModal = (id) => {
    if (document.querySelector('.modal-backdrop')) return;

    const modal = new bootstrap.Modal(document.getElementById(id));
    modal.show();
};

window.hideModal = (id) => {
    const modalElement = document.getElementById(id);
    const modalInstance = bootstrap.Modal.getInstance(modalElement);
    if (modalInstance) {
        modalInstance.hide();
    }
};