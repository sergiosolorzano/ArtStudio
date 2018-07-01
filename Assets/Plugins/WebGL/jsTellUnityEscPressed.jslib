
document.onkeydown = function(evt) 
{
    evt = evt || window.event;
    if (evt.keyCode == 27) 
	    {
	        alertconsole.log("Key pressed: "+evt.keyCode);
		SendMessage("EscMssgImage", "SwitchMssg");
	    }
};