import React, { Component } from "react";
import { connect } from "react-redux";
import { SHOW_MESSAGE } from "../../redux/actionTypes";

class MessageBox extends Component
{

    closeModal()
    {
        this.props.dispatch({ type: SHOW_MESSAGE, payload: { messageType: "", lastText: "" } });
    }

    renderMessageBox()
    {

        let messageHeader = "";
        switch (this.props.message.messageType)
        {

            case "MESSAGE_INFO":
                messageHeader = "Information";
                break;

            case "MESSAGE_WARN":
                messageHeader = "Warning";
                break;

            case "MESSAGE_ERROR":
                messageHeader = "Error";
                break;

            default:
                messageHeader = "Information";

        }

        return (

            <div>

                <div className="modal">
                    <div className="modal-content">
                        <h4>{messageHeader}</h4>
                        <p>{this.props.message.lastText}</p>
                    </div>
                    <div className="modal-footer">
                        <div className="modal-close waves-effect waves-green btn-flat" onClick={() => this.closeModal}>OK</div>
                    </div>
                </div>

            </div>
            
        );

    }

    render()
    {

        let rendered = this.props.isShown ? this.renderMessageBox() : null;

        return (

            <div>
                {rendered}
            </div>

        );

    }

}

const mapStateToProps = (state) =>
{
    let isVisible = true;
    if (state.message.lastText === "") { isVisible = false; }
    return { isShown: isVisible, message: state.message }
}

export default connect(mapStateToProps)(MessageBox)
