const showModal = name => {
  document.getElementById(`${name}-modal`).classList.remove('obscured');
}
const hideModal = name => {
  document.getElementById(`${name}-modal`).classList.add('obscured');
}