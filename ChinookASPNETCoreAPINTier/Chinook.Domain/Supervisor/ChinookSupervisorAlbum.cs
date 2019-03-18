using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Chinook.Domain.ViewModels;
using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public async Task<List<AlbumViewModel>> GetAllAlbumAsync(CancellationToken ct = default(CancellationToken))
        {
            var albums = AlbumCoverter.ConvertList(await _albumRepository.GetAllAsync(ct));
            return albums;
        }

        public async Task<AlbumViewModel> GetAlbumByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var albumViewModel = AlbumCoverter.Convert(await _albumRepository.GetByIdAsync(id, ct));
            albumViewModel.ArtistName = _artistRepository.GetByIdAsync(albumViewModel.ArtistId, ct).Result.Name;
            return albumViewModel;
        }

        public async Task<List<AlbumViewModel>> GetAlbumByArtistIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var albums = AlbumCoverter.ConvertList(await _albumRepository.GetByArtistIdAsync(id, ct));
            return albums;
        }

        public async Task<AlbumViewModel> AddAlbumAsync(AlbumViewModel newAlbumViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var album = new Album
            {
                Title = newAlbumViewModel.Title,
                ArtistId = newAlbumViewModel.ArtistId
            };

            album = await _albumRepository.AddAsync(album, ct);
            newAlbumViewModel.AlbumId = album.AlbumId;
            return newAlbumViewModel;
        }

        public async Task<bool> UpdateAlbumAsync(AlbumViewModel albumViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var album = await _albumRepository.GetByIdAsync(albumViewModel.AlbumId, ct);

            if (album == null) return false;
            album.AlbumId = albumViewModel.AlbumId;
            album.Title = albumViewModel.Title;
            album.ArtistId = albumViewModel.ArtistId;

            return await _albumRepository.UpdateAsync(album, ct);
        }

        public async Task<bool> DeleteAlbumAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _albumRepository.DeleteAsync(id, ct);
        }
    }
}