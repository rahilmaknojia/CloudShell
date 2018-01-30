// Write your JavaScript code.

// Shell Prompt Events

$(".shell-input-prompt").keydown(function (e) {
    var k = (e.keyCode ? e.keyCode : e.which);  
    // Perform action on enter key event.
    if (k == 13) {
        var val = $(this).val();
        if (val == '')
        {
            // Stop further execution if no command is typed.
            e.preventDefault();
        }
        else
        {
            var lastChar = val[val.length - 1];
            if (lastChar === "`")
            {
                // Add new line if special char is detected.
                console.log(lastChar);
                var rows = $(this).attr("rows");
                rows = parseInt(rows) + 1;
                $(this).attr("rows", rows);
            }
            else
            {
                // Perform Execution of full command
                    // Code logic goes here

                // Add output on top
                var clone = $(".shell-prompt-tag .shell-prompt-container").clone();
                $(".capture-output").append(clone);
                // Disable textarea once it is cloned.
                $(".capture-output").find("textarea").attr("disabled", true);
                // Clear value from textarea
                $(".shell-prompt-tag").find("textarea").val("");
                // Stop further execution if no special char is detected.
                e.preventDefault();
                // Insert updates
                $(".capture-output").append("No output");
            }
        }
    }
});