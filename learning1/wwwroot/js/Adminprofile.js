const editButton1 = document.querySelector('.edit-button1');
const saveButton1 = document.querySelector('.save-button1');
const cancelButton1 = document.querySelector('.cancel-button1');

editButton1.addEventListener('click', () => {
    // Find all form controls within the element with class Admin_Update2
    const formControls = document.querySelector('.Admin_Update1').querySelectorAll('.form-control, .form-check-input');

    // Remove disabled attribute from these form controls
    formControls.forEach(control => control.removeAttribute('disabled'));

    // Hide edit button and show save and cancel buttons
    editButton1.classList.add('d-none');
    saveButton1.classList.remove('d-none'); // Show save button
    cancelButton1.classList.remove('d-none'); // Show cancel button
});

// Add event listener for the save button (assuming form submission)
saveButton1.addEventListener('click', () => {


    const formControls = document.querySelector('.Admin_Update1').querySelectorAll('.form-control, .form-check-input');

    // Remove disabled attribute from these form controls
   // formControls.forEach(control => control.setAttribute('disabled', 'true'));


    // Hide edit button and show save and cancel buttons
    editButton1.classList.remove('d-none');
    saveButton1.classList.add('d-none'); // Show save button
    cancelButton1.classList.add('d-none'); // Show cancel button
    console.log('Saving form data...'); 
});

// Add event listener for the cancel button (assuming it resets the form)
cancelButton1.addEventListener('click', () => {

    const formControls = document.querySelector('.Admin_Update1').querySelectorAll('.form-control, .form-check-input');

    // Remove disabled attribute from these form controls
    formControls.forEach(control => control.setAttribute('disabled', 'true'));


    // Hide edit button and show save and cancel buttons
    editButton1.classList.remove('d-none');
    saveButton1.classList.add('d-none'); // Show save button
    cancelButton1.classList.add('d-none'); // Show cancel button
    console.log('Canceling edit...'); 
});







const editButton2 = document.querySelector('.edit-button2');
const saveButton2 = document.querySelector('.save-button2');
const cancelButton2 = document.querySelector('.cancel-button2');

editButton2.addEventListener('click', () => {
    // Find all form controls within the element with class Admin_Update2
    const formControls = document.querySelector('.Admin_Update2').querySelectorAll('.form-control, .form-check-input');

    // Remove disabled attribute from these form controls
    formControls.forEach(control => control.removeAttribute('disabled'));

    // Hide edit button and show save and cancel buttons
    editButton2.classList.add('d-none');
    saveButton2.classList.remove('d-none'); // Show save button
    cancelButton2.classList.remove('d-none'); // Show cancel button
});

// Add event listener for the save button (assuming form submission)
saveButton2.addEventListener('click', () => {
    const formControls = document.querySelector('.Admin_Update2').querySelectorAll('.form-control, .form-check-input');

    // Remove disabled attribute from these form controls
    //formControls.forEach(control => control.setAttribute('disabled', 'true'));


    // Hide edit button and show save and cancel buttons
    editButton2.classList.remove('d-none');
    saveButton2.classList.add('d-none'); // Show save button
    cancelButton2.classList.add('d-none'); // Show cancel button
    console.log('Saving form data...');
});

// Add event listener for the cancel button (assuming it resets the form)
cancelButton2.addEventListener('click', () => {

    const formControls = document.querySelector('.Admin_Update2').querySelectorAll('.form-control, .form-check-input');

    // Remove disabled attribute from these form controls
    formControls.forEach(control => control.setAttribute('disabled', 'true'));


    // Hide edit button and show save and cancel buttons
    editButton2.classList.remove('d-none');
    saveButton2.classList.add('d-none'); // Show save button
    cancelButton2.classList.add('d-none'); // Show cancel button
    console.log('Canceling edit...');
});