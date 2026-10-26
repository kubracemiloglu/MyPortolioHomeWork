document.addEventListener('submit', function (event) {
    if (event.target.matches('[data-confirm-delete]') && !window.confirm('Bu kaydı silmek istediğine emin misin?')) {
        event.preventDefault();
    }
});
