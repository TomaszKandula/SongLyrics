import React, { Component } from "react";
import M from "materialize-css";
import { MESSAGE_INFO, MESSAGE_WARN, MESSAGE_ERROR } from "../../shared/constants";

class Modal extends Component
{
    componentDidMount()
    {
        const options =
        {
            onOpenStart: null,
            onOpenEnd: null,
            onCloseStart: null,
            onCloseEnd: null,
            inDuration: 250,
            outDuration: 250,
            opacity: 0.5,
            dismissible: false,
            startingTop: "4%",
            endingTop: "10%"
        };

        M.Modal.init(this.Modal, options);
        if (this.props.isOpened)
        {
            // Render modal window with time lag to improve UX
            setTimeout(() =>
            {
                const instance = M.Modal.getInstance(this.Modal);
                instance.open();
            }, 500);
        }
    }

    setHeader(selection)
    {
        switch (selection)
        {
            case MESSAGE_INFO: return "Information";
            case MESSAGE_WARN: return "Warning";
            case MESSAGE_ERROR: return "Error";
            default: return "Information";
        }
    }

    render()
    {
        return (
            <>
                <div ref={Modal => { this.Modal = Modal; }} id="main-modal" className="modal">
                    <div className="modal-content">
                        <h4>{this.setHeader(this.props.messageType)}</h4>
                        <p>{this.props.messageText}</p>
                    </div>
                    <div className="modal-footer">
                        <a href="#!" className="modal-close waves-effect waves-green btn-flat">
                            OK
                        </a>
                    </div>
                </div>
            </>
        );
    }
}

export default Modal;
