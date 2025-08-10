window.showModal = (id) => {
    const modal = new bootstrap.Modal(document.getElementById(id));
    modal.show();
};