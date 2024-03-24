function ShowkDialog(message, showYesNoBtn, showOkBtn, showWaiting) {
    return new Promise((resolve, reject) => {
        // Create a dialog element
        var dialog = document.createElement('div');
        dialog.id = 'kDialog';
        var cssString = '';
        cssString += 'position: fixed; top: 0; left: 0; width: 100%;';
        cssString += 'height: 100%; background-color: rgba(0, 0, 0, 0.5);';
        cssString += ' display: flex; justify-content: center; align-items:';
        cssString += 'center; z-index: 9999;';
        dialog.style.cssText = cssString; 

        // Create content for the dialog
        var dialogContent = document.createElement('div');
        cssString = '';
        cssString += 'min-width: 300px; min-height: 150px;';
        cssString += 'padding: 10px 30px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.2); ';
        cssString += 'text-align: center; position: relative;background-color: white;';
        dialogContent.style.cssText = cssString;

        // Add waiting gif if needed
        if (showWaiting) {
            var waitingGif = document.createElement('img');
            waitingGif.src = '/img/waiting.gif';
            waitingGif.alt = 'Waiting';
            waitingGif.style.cssText = 'position: absolute;top: calc((100% - 64px)/2) ;left: 50%;transform: translateX(-50%);z-index: 99999;width: 64px;height: 64px;';
            dialogContent.appendChild(waitingGif);
        }

        // Add message
        var messageParagraph = document.createElement('p');
        messageParagraph.id = 'kDialogMsg';
        messageParagraph.textContent = message;
        messageParagraph.style.cssText = 'margin-top: 0px;background-color: #007bff;';
        dialogContent.appendChild(messageParagraph);

        // Add buttons
        var buttonsDiv = document.createElement('div');
        buttonsDiv.style.cssText = 'position: absolute; bottom: 10px; left: 50%; transform: translateX(-50%); text-align: center; margin-top: 20px;';

        if (showYesNoBtn) {
            //add yes button
            var yesButton = document.createElement('button');
            yesButton.id = 'yesButton';
            yesButton.textContent = 'Yes';
            yesButton.style.cssText = 'padding: 10px 20px; margin: 0 10px; border: none; border-radius: 5px; cursor: pointer; background-color:#007bff;';
            yesButton.addEventListener('click', () => {
                resolve(true);
                document.body.removeChild(dialog);
            });
            yesButton.addEventListener('mouseover', function() { this.style.backgroundColor = '#0056b3'; });
            yesButton.addEventListener('mouseout', function() { this.style.backgroundColor = '#007bff'; });
            buttonsDiv.appendChild(yesButton);

            //add no button
            var noButton = document.createElement('button');
            noButton.id = 'noButton';
            noButton.textContent = 'No';
            noButton.style.cssText = 'padding: 10px 20px; margin: 0 10px; border: none; border-radius: 5px; cursor: pointer; background-color:#007bff;';
            noButton.addEventListener('click', () => {
                resolve(false);
                document.body.removeChild(dialog);
            });
            noButton.addEventListener('mouseover', function() { this.style.backgroundColor = '#0056b3'; });
            noButton.addEventListener('mouseout', function() { this.style.backgroundColor = '#007bff'; });
            buttonsDiv.appendChild(noButton);
        }

        //ok button 
        var okButton = document.createElement('button');
        okButton.id = 'okButton';
        okButton.textContent = 'OK';
        okButton.style.cssText = 'padding: 10px 20px; margin: 0 10px; border: none; border-radius: 5px; cursor: pointer; background-color:#007bff;';
        okButton.addEventListener('click', () => {
            resolve(false);
            document.body.removeChild(dialog);
        });
        okButton.addEventListener('mouseover', function() { this.style.backgroundColor = '#0056b3'; });
        okButton.addEventListener('mouseout', function() { this.style.backgroundColor = '#007bff'; });
        buttonsDiv.appendChild(okButton);
        if (!showOkBtn) {
            okButton.style.display = 'none';
        }
    

        dialogContent.appendChild(buttonsDiv);
        dialog.appendChild(dialogContent);

        // Append dialog to the body
        document.body.appendChild(dialog);
    });
}

function HidekDialog(){
    var kDialog = document.getElementById('kDialog');
    document.body.removeChild(kDialog);
}