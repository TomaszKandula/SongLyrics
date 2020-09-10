import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as Posed from "../common/posedComponents";

class SongBox extends Component
{







}

const mapStateToProps = (state) =>
{
    let isVisible = true;
    if (state.song.id === 0) { isVisible = false; }
    return { isShown: isVisible, songId: state.song.id }
}

export default connect(mapStateToProps)(SongBox)
