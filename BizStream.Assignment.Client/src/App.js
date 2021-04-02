import './App.css';

function App() {
    const submitForm = async (e) => {
        e.preventDefault();

        const responseMessage = document.getElementById("response-message");

        let isValid = true;
        const form = new FormData(e.target);
        // TODO: Proper validation beyond "not provided"
        form.forEach(entry => {
            isValid = isValid && entry;
        });

        if (!isValid) {
            responseMessage.textContent = "Please fix any mistakes and try again";
            responseMessage.setAttribute("data-error", "");
            return;
        } else {
            responseMessage.removeAttribute("data-error");
        }

        const formData = Object.fromEntries(form.entries());
        console.debug(formData);

        const response = await fetch(
            "http://localhost:12345/api/contactUs",
            {
                method: "POST",
                headers: {"Content-Type": "application/json;charset=UTF-8"},
                body: JSON.stringify(formData),
                cache: "no-cache"
            });

        console.debug(response);
        document.getElementById("response-message").textContent = response.ok
            ? "Thank you for contacting us!"
            : "We're sorry, something went wrong...";

        if (response.ok) {
            responseMessage.removeAttribute("data-error");
        } else {
            responseMessage.setAttribute("data-error", "");
        }

        if (response.ok) {
            const inputs = document.getElementsByClassName("form-input");
            for (let index = 0; index < inputs.length; index++) {
                inputs.item(index).textContent = undefined;
            }
        }
    };

    return (
        <div className="form-wrapper">
            <div id="response-message" />
            <form id="contact-us-form" className="form" onSubmit={submitForm}>
                <h1>Contact Us Form</h1>
                <label>First Name</label>
                <input type="text" name="firstName" className="form-input" />

                <label>Last Name</label>
                <input type="text" name="lastName" className="form-input" />

                <label>Email</label>
                <input type="email" name="email" className="form-input" />

                <label>Message</label>
                <textarea name="message" className="form-input form-input-multi" />

                <button className="button-submit">SUBMIT</button>
            </form>
        </div>
    );
}

export default App;
