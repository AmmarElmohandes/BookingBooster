import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';
import { AppState } from '../State/app.state';
import { HostOrUserReducer } from './hostOruser.reducer';
import { HostReducer } from './hosts.reducer';
import { hydrationMetaReducer } from './hydration.reducers';
import { PropertyReducer } from './property.reducer';

export interface State {

}

export const reducers: ActionReducerMap<AppState> = {
hostId:HostReducer,
propertyId:PropertyReducer,
hostOruser:HostOrUserReducer
};


export const metaReducers: MetaReducer[]=[hydrationMetaReducer]